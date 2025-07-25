using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaDatos;
using CapaEntidades;

namespace InventZetaGas
{
    public partial class Archivos : Form
    {

        private int batchSize = 1000;  // Tamaño del lote, puedes ajustarlo según sea necesario
        private int currentBatch = 0;   // Índice del lote actual
        private List<List<object>> allRows = new List<List<object>>();  // Lista completa de filas para paginación
        private List<string> columnHeaders = new List<string>(); // Para almacenar los encabezados de las columnas

        public Archivos()
        {
            InitializeComponent();
        }

        private async void btnModify_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdArchivo = new OpenFileDialog();
            fdArchivo.Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            fdArchivo.Title = "Seleccionar archivo de Excel";

            if (fdArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    columnHeaders.Clear(); // Limpiar la lista antes de cargar nuevos datos
                    allRows.Clear(); // Limpiar la lista antes de cargar nuevos datos

                    // Cargar el archivo Excel en segundo plano para no congelar la interfaz
                    await Task.Run(() =>
                    {
                        // Abrir el archivo Excel con ClosedXML
                        var workbook = new XLWorkbook(fdArchivo.FileName);
                        var worksheet = workbook.Worksheet(1);  // Cargar la primera hoja del Excel

                        bool firstRow = true;

                        // Recorrer todas las filas del archivo Excel
                        foreach (var row in worksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                // Capturar los encabezados de las columnas
                                foreach (var cell in row.Cells())
                                {
                                    columnHeaders.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                // Crear una lista de objetos para la fila actual
                                List<object> currentRowData = new List<object>();
                                foreach (var cell in row.Cells())
                                {
                                    currentRowData.Add(cell.Value);
                                }
                                allRows.Add(currentRowData);  // Almacenar todas las filas en la lista
                            }
                        }
                    }); // Fin de Task.Run

                    // Ahora, en el hilo de la UI (después de que await Task.Run finalice)
                    BeginInvoke(new Action(() =>
                    {
                        // Limpiar y agregar columnas al DataGridView
                        dgvExcel.Columns.Clear();
                        // Asegurarse de que la generación automática de columnas esté deshabilitada para el modo virtual
                        dgvExcel.AutoGenerateColumns = false; 
                        foreach (string header in columnHeaders)
                        {
                            dgvExcel.Columns.Add(header, header);
                        }

                        // Mensaje de depuración para verificar el conteo de columnas
                        MessageBox.Show($"Número de columnas agregadas: {dgvExcel.Columns.Count}"); 

                        // Establecer la cantidad total de filas
                        txtCantidad.Text = allRows.Count.ToString();
                        dgvExcel.RowCount = allRows.Count;
                        dgvExcel.Refresh();
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Archivos_Load(object sender, EventArgs e)
        {
            dgvExcel.VirtualMode = true;
            dgvExcel.RowCount = 0;  // Inicializa con 0 filas
            dgvExcel.CellValueNeeded += dgvExcel_CellValueNeeded; // Suscribir el evento aquí
        }

        private void dgvExcel_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < allRows.Count)
            {
                List<object> rowData = allRows[e.RowIndex];
                if (e.ColumnIndex >= 0 && e.ColumnIndex < rowData.Count)
                {
                    e.Value = rowData[e.ColumnIndex];
                }
            }
        }

        private async Task GuardarLotesEnBaseDeDatos()
        {
            int batchSaveSize = 100000; // 100,000 registros por lote
            VentasN ventasNegocio = new VentasN(); // Instanciar la clase de negocio

            while (allRows.Count > 0)
            {
                int recordsToProcess = Math.Min(batchSaveSize, allRows.Count);
                List<List<object>> currentBatchRaw = allRows.GetRange(0, recordsToProcess);
                List<VentasE> ventasParaGuardar = new List<VentasE>();

                // Mapear los datos raw del Excel a objetos VentasE
                foreach (var rowData in currentBatchRaw)
                {
                    VentasE venta = new VentasE();
                    for (int i = 0; i < columnHeaders.Count; i++)
                    {
                        string header = columnHeaders[i];
                        object value = rowData.Count > i ? rowData[i] : null; // Manejar filas con menos columnas

                        try
                        {
                            // Mapeo basado en el esquema de la tabla Ventas
                            switch (header)
                            {
                                case "Planta": venta.Planta = Convert.ToString(value); break;
                                case "Planta_ID": venta.Planta_ID = value != null ? Convert.ToInt32(value) : 0; break;
                                case "Vendedor": venta.Vendedor = Convert.ToString(value); break;
                                case "Ruta": venta.Ruta = Convert.ToString(value); break;
                                case "Fecha": venta.Fecha = value != null ? Convert.ToDateTime(value) : DateTime.MinValue; break;
                                case "Mes": venta.Mes = Convert.ToString(value); break;
                                case "Codigo_Cliente": venta.Codigo_Cliente = value != null ? Convert.ToInt32(value) : 0; break;
                                case "Cliente": venta.Cliente = Convert.ToString(value); break;
                                case "Tipo_Cliente": venta.Tipo_Cliente = Convert.ToString(value); break;
                                case "Categoria_Cliente": venta.Categoria_Cliente = Convert.ToString(value); break;
                                case "Codigo_Subcliente": venta.Codigo_Subcliente = value != null ? Convert.ToInt32(value) : 0; break;
                                case "Subcliente": venta.Subcliente = Convert.ToString(value); break;
                                case "Producto": venta.Producto = Convert.ToString(value); break;
                                case "Categoria": venta.Categoria = Convert.ToString(value); break;
                                case "Cantidad": venta.Cantidad = value != null ? Convert.ToDecimal(value) : 0m; break;
                                case "Litros": venta.Litros = value != null ? Convert.ToDecimal(value) : 0m; break;
                                case "Otros_Impuestos": venta.Otros_Impuestos = value != null ? Convert.ToDecimal(value) : 0m; break;
                                case "Total": venta.Total = value != null ? Convert.ToDecimal(value) : 0m; break;
                                default: /* Ignorar columnas no mapeadas */ break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error de conversión para columna '{header}' con valor '{value}': {ex.Message}");
                            // Considerar asignar valores predeterminados o lanzar una excepción específica
                        }
                    }
                    ventasParaGuardar.Add(venta);
                }

                try
                {
                    MessageBox.Show($"Guardando {recordsToProcess} registros en la base de datos...");

                    // Llamar al método de inserción masiva en la capa de negocio
                    await ventasNegocio.InsertarVentasBulk(ventasParaGuardar);

                    // Una vez guardado, eliminar del principio de allRows
                    allRows.RemoveRange(0, recordsToProcess);

                    BeginInvoke(new Action(() =>
                    {
                        txtCantidad.Text = allRows.Count.ToString(); // Actualizar el contador de registros restantes
                        dgvExcel.RowCount = allRows.Count; // Actualizar el DataGridView
                        dgvExcel.Refresh();
                    }));

                    MessageBox.Show($"Lote de {recordsToProcess} registros guardado y eliminado de memoria. Registros restantes: {allRows.Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar un lote: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Puedes decidir si quieres detener el proceso o intentar con el siguiente lote
                    break; // Detener el proceso en caso de error
                }
            }

            if (allRows.Count == 0)
            {
                MessageBox.Show("Todos los registros han sido guardados en la base de datos.");
            }
        }

        private async void btnGuardarLotes_Click(object sender, EventArgs e)
        {
            if (allRows.Count == 0)
            {
                MessageBox.Show("No hay registros para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            await GuardarLotesEnBaseDeDatos();
        }

        // Los métodos btnCargarMas_Click y btnAdd_Click ya no son necesarios para la paginación con VirtualMode
        // Se pueden eliminar o comentar si no tienen otro propósito.

    }


}
