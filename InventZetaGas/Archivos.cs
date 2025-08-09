using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaDatos;
using CapaEntidades;
using DocumentFormat.OpenXml.Vml.Office;

namespace InventZetaGas
{
    public partial class Archivos : Form
    {

        private int batchSize = 1000;  // Tamaño del lote, puedes ajustarlo según sea necesario
        private int currentBatch = 0;   // Índice del lote actual
        private List<List<object>> allRows = new List<List<object>>();  // Lista completa de filas para paginación
        private List<string> columnHeaders = new List<string>(); // Para almacenar los encabezados de las columnas
        private bool isLoadingFile = false; // Flag para controlar si se está cargando un archivo
        

        public Archivos()
        {
            InitializeComponent();
        }

        private async void btnModify_Click(object sender, EventArgs e)
        {
            // Validar si ya se está cargando un archivo
            if (isLoadingFile)
            {
                MessageBox.Show("Ya se está cargando un archivo. Por favor espere a que termine el proceso.", "Archivo en proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenFileDialog fdArchivo = new OpenFileDialog();
            fdArchivo.Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            fdArchivo.Title = "Seleccionar archivo de Excel";

            if (fdArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    isLoadingFile = true; // Marcar que se está cargando un archivo

                    // Guardar el nombre del archivo en txtarchivo
                    txtarchivo.Text = System.IO.Path.GetFileName(fdArchivo.FileName);

                    columnHeaders.Clear(); // Limpiar la lista antes de cargar nuevos datos
                    allRows.Clear(); // Limpiar la lista antes de cargar nuevos datos

                    // Configurar y mostrar ProgressBar
                    BeginInvoke(new Action(() =>
                    {
                        progressBar1.Style = ProgressBarStyle.Marquee;
                        progressBar1.MarqueeAnimationSpeed = 30;
                        progressBar1.Visible = true;
                    }));

                    // Cargar el archivo Excel en segundo plano para no congelar la interfaz
                    await Task.Run(() =>
                    {
                        // Abrir el archivo Excel con ClosedXML
                        var workbook = new XLWorkbook(fdArchivo.FileName);
                        var worksheet = workbook.Worksheet(1);  // Cargar la primera hoja del Excel

                        // Obtener el número total de filas para el progreso
                        var totalRows = worksheet.RowsUsed().Count();
                        int currentRowIndex = 0;
                        bool firstRow = true;

                        BeginInvoke(new Action(() =>
                        {
                            progressBar1.Style = ProgressBarStyle.Blocks;
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = totalRows;
                            progressBar1.Value = 0;
                        }));

                        // Recorrer todas las filas del archivo Excel
                        foreach (var row in worksheet.RowsUsed())
                        {
                            currentRowIndex++;

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

                            // Actualizar ProgressBar cada 1000 filas para no sobrecargar la UI
                            if (currentRowIndex % 1000 == 0 || currentRowIndex == totalRows)
                            {
                                BeginInvoke(new Action(() =>
                                {
                                    progressBar1.Value = Math.Min(currentRowIndex, progressBar1.Maximum);
                                }));
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

                        // Establecer la cantidad total de filas
                        txtCantidad.Text = allRows.Count.ToString();
                        dgvExcel.RowCount = allRows.Count;
                        dgvExcel.Refresh();

                        // Mostrar columnas detectadas en consola para debugging
                        Console.WriteLine("=== COLUMNAS DETECTADAS EN EXCEL ===");
                        for (int i = 0; i < columnHeaders.Count; i++)
                        {
                            Console.WriteLine($"{i}: '{columnHeaders[i]}'");
                        }
                        Console.WriteLine("====================================");

                        // Ocultar ProgressBar y mostrar mensaje de éxito
                        progressBar1.Visible = false;
                        MessageBox.Show($"Archivo cargado exitosamente. Número de columnas: {dgvExcel.Columns.Count}, Filas: {allRows.Count}");

                        isLoadingFile = false; // Marcar que terminó la carga
                    }));
                }
                catch (Exception ex)
                {
                    BeginInvoke(new Action(() =>
                    {
                        progressBar1.Visible = false; // Ocultar ProgressBar en caso de error
                    }));
                    isLoadingFile = false; // Marcar que terminó la carga (con error)
                    MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                isLoadingFile = false; // Marcar que no se seleccionó archivo
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

        private async Task GuardarPrimeros300000Registros()
        {
            const int MAX_RECORDS = 300000;
            const int BATCH_SIZE = 10000; // Lotes más pequeños para mejor rendimiento

            VentasN ventasNegocio = new VentasN();
            int totalGuardados = 0;
            int registrosParaProcesar = Math.Min(MAX_RECORDS, allRows.Count);

            try
            {
                // Probar la conexión a la base de datos antes de iniciar
                if (!await ProbarConexionBaseDatos())
                {
                    MessageBox.Show("No se puede conectar a la base de datos. Verifique la configuración de conexión.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Configurar ProgressBar
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = registrosParaProcesar;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                Application.DoEvents();

                Console.WriteLine($"Iniciando guardado de {registrosParaProcesar} registros en lotes de {BATCH_SIZE}");

                // Procesar en lotes hasta alcanzar 300,000 registros
                for (int indiceInicio = 0; indiceInicio < registrosParaProcesar; indiceInicio += BATCH_SIZE)
                {
                    // Calcular cuántos registros tomar en este lote
                    int registrosEnLote = Math.Min(BATCH_SIZE, registrosParaProcesar - indiceInicio);
                    int registrosDisponibles = Math.Min(registrosEnLote, allRows.Count);

                    if (registrosDisponibles <= 0) break;

                    // Tomar los primeros registros del allRows
                    List<List<object>> loteActual = allRows.GetRange(0, registrosDisponibles);
                    List<VentasE> ventasLote = new List<VentasE>();

                    Console.WriteLine($"Procesando lote {(indiceInicio / BATCH_SIZE) + 1}: {registrosDisponibles} registros");

                    // Convertir los datos raw a objetos VentasE
                    foreach (var fila in loteActual)
                    {
                        VentasE venta = ConvertirFilaAVenta(fila);
                        if (venta != null)
                        {
                            ventasLote.Add(venta);
                        }
                    }

                    // Guardar el lote en la base de datos
                    if (ventasLote.Count > 0)
                    {
                        try
                        {
                            Console.WriteLine($"Intentando guardar {ventasLote.Count} registros en la base de datos...");
                            await ventasNegocio.InsertarVentasBulk(ventasLote);

                            // Eliminar los registros procesados de allRows
                            allRows.RemoveRange(0, registrosDisponibles);
                            totalGuardados += registrosDisponibles;

                            // Actualizar interfaz
                            progressBar1.Value = totalGuardados;
                            txtCantidad.Text = allRows.Count.ToString();
                            dgvExcel.RowCount = allRows.Count;
                            dgvExcel.Refresh();
                            Application.DoEvents();

                            Console.WriteLine($"✓ Lote guardado exitosamente. Total: {totalGuardados}/{registrosParaProcesar}, Restantes: {allRows.Count}");
                        }
                        catch (Exception exLote)
                        {
                            string errorDetallado = $"Error al guardar lote {(indiceInicio / BATCH_SIZE) + 1}: {exLote.Message}";
                            if (exLote.InnerException != null)
                            {
                                errorDetallado += $"\nError interno: {exLote.InnerException.Message}";
                            }
                            Console.WriteLine($"❌ {errorDetallado}");
                            throw new Exception(errorDetallado, exLote);
                        }
                    }

                    // Si ya guardamos 300,000, parar
                    if (totalGuardados >= MAX_RECORDS)
                    {
                        break;
                    }
                }

                // Proceso completado
                progressBar1.Visible = false;
                string mensaje = $"Proceso completado exitosamente.\n" +
                               $"Registros guardados: {totalGuardados:N0}\n" +
                               $"Registros restantes en memoria: {allRows.Count:N0}";

                Console.WriteLine($"PROCESO COMPLETADO: {totalGuardados} registros guardados, {allRows.Count} restantes");
                MessageBox.Show(mensaje, "Guardado Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar1.Visible = false;
                string errorMsg = $"Error durante el proceso de guardado: {ex.Message}";
                Console.WriteLine($"ERROR: {errorMsg}");
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private VentasE ConvertirFilaAVenta(List<object> fila)
        {
            try
            {
                VentasE venta = new VentasE();

                // Debug: mostrar encabezados y valores para la primera fila
                if (fila == allRows.FirstOrDefault())
                {
                    Console.WriteLine("=== DEBUG: Encabezados y valores de la primera fila ===");
                    for (int debug = 0; debug < columnHeaders.Count && debug < fila.Count; debug++)
                    {
                        Console.WriteLine($"Columna {debug}: '{columnHeaders[debug]}' = '{fila[debug]}'");
                    }
                    Console.WriteLine("===============================================");
                }

                for (int i = 0; i < columnHeaders.Count && i < fila.Count; i++)
                {
                    string header = columnHeaders[i];
                    object value = fila[i];

                    // Debug específico para código de cliente
                    if (header.ToUpper().Contains("CLIENTE") && header.ToUpper().Contains("CODIGO"))
                    {
                        Console.WriteLine($"DEBUG Codigo_Cliente: Columna='{header}' Valor='{value}' Tipo={value?.GetType().Name}");
                    }

                    switch (header.ToUpper())
                    {
                        case "PLANTA":
                            venta.Planta = Convert.ToString(value) ?? "";
                            break;
                        case "PLANTA_ID":
                        case "PLANTAID":
                            venta.PlantaID = ConvertToInt(value);
                            break;
                        case "RUTA":
                            venta.Ruta = Convert.ToString(value) ?? "";
                            break;
                        case "RUTA_ID":
                        case "RUTAID":
                            venta.RutaID = ConvertToInt(value);
                            break;
                        case "VENDEDOR":
                            venta.Vendedor = Convert.ToString(value) ?? "";
                            break;
                        case "VENDEDOR_ID":
                        case "VENDEDORID":
                            venta.VendedorID = ConvertToInt(value);
                            break;
                        case "FECHA":
                            venta.Fecha = ConvertToDateTime(value);
                            break;
                        case "MES":
                            venta.Mes = Convert.ToString(value) ?? ""; // Mantener para compatibilidad
                            break;
                        case "CODIGO_CLIENTE":
                        case "CODIGOCLIENTE":
                        case "CODIGO CLIENTE":
                        case "COD_CLIENTE":
                        case "CODCLIENTE":
                        case "COD CLIENTE":
                        case "CLIENT_CODE":
                        case "CLIENTCODE":
                        case "CLIENTE_ID":
                        case "CLIENTEID":
                        case "ID_CLIENTE":
                        case "IDCLIENTE":
                            Console.WriteLine($"MAPEO CODIGO_CLIENTE: '{header}' = '{value}' -> {ConvertToInt(value)}");
                            venta.Codigo_Cliente = ConvertToInt(value);
                            break;
                        case "CLIENTE":
                            venta.Cliente = Convert.ToString(value) ?? "";
                            break;
                        case "TIPO_CLIENTE":
                            venta.Tipo_Cliente = Convert.ToString(value) ?? "";
                            break;
                        case "CATEGORIA_CLIENTE":
                            venta.Categoria_Cliente = Convert.ToString(value) ?? "";
                            break;
                        case "CODIGO_SUBCLIENTE":
                            venta.Codigo_Subcliente = ConvertToInt(value);
                            break;
                        case "SUBCLIENTE":
                            venta.Subcliente = Convert.ToString(value) ?? "";
                            break;
                        case "PRODUCTO":
                            venta.Producto = Convert.ToString(value) ?? "";
                            break;
                        case "CATEGORIA":
                            venta.Categoria = Convert.ToString(value) ?? "";
                            break;
                        case "CANTIDAD":
                            venta.Cantidad = ConvertToDecimal(value);
                            break;
                        case "LITROS":
                            venta.Litros = ConvertToDecimal(value);
                            break;
                        case "OTROS_IMPUESTOS":
                            venta.Otros_Impuestos = ConvertToDecimal(value);
                            break;
                        case "TOTAL":
                            venta.Total = ConvertToDecimal(value);
                            break;
                    }
                }

                // Asignar valores por defecto para campos obligatorios si no se encontraron en el Excel
                if (venta.PlantaID == 0 && !string.IsNullOrEmpty(venta.Planta))
                {
                    venta.PlantaID = 1; // Valor por defecto, ajustar según sea necesario
                }

                if (venta.RutaID == 0 && !string.IsNullOrEmpty(venta.Ruta))
                {
                    venta.RutaID = 1; // Valor por defecto, ajustar según sea necesario
                }

                if (venta.VendedorID == 0 && !string.IsNullOrEmpty(venta.Vendedor))
                {
                    venta.VendedorID = 1; // Valor por defecto, ajustar según sea necesario
                }

                // Validar que los campos obligatorios no estén vacíos
                if (venta.Fecha == DateTime.MinValue)
                {
                    venta.Fecha = DateTime.Now; // Usar fecha actual como fallback
                }

                // Solo asignar valor por defecto si realmente no se pudo leer del Excel
                if (venta.Codigo_Cliente == 0)
                {
                    Console.WriteLine($"WARNING: Codigo_Cliente es 0, asignando valor por defecto");
                    venta.Codigo_Cliente = 1; // Cliente por defecto
                }
                else
                {
                    Console.WriteLine($"Codigo_Cliente leído correctamente: {venta.Codigo_Cliente}");
                }

                return venta;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al convertir fila: {ex.Message}");
                return null;
            }
        }

        private int ConvertToInt(object value)
        {
            if (value == null) return 0;

            // Manejar diferentes tipos que pueden venir del Excel
            switch (value)
            {
                case int intValue:
                    return intValue;
                case double doubleValue:
                    return (int)doubleValue;
                case decimal decimalValue:
                    return (int)decimalValue;
                case float floatValue:
                    return (int)floatValue;
                case string stringValue:
                    // Limpiar espacios y caracteres especiales
                    stringValue = stringValue.Trim();
                    if (string.IsNullOrEmpty(stringValue)) return 0;

                    // Remover comas, puntos decimales solo si es un número entero
                    if (stringValue.Contains(".") && stringValue.Split('.')[1].All(c => c == '0'))
                    {
                        stringValue = stringValue.Split('.')[0];
                    }

                    if (int.TryParse(stringValue, out int result))
                    {
                        Console.WriteLine($"ConvertToInt: '{value}' -> {result}");
                        return result;
                    }

                    // Intentar como double y convertir a int
                    if (double.TryParse(stringValue, out double doubleResult))
                    {
                        int intResult = (int)doubleResult;
                        Console.WriteLine($"ConvertToInt (via double): '{value}' -> {intResult}");
                        return intResult;
                    }
                    break;
            }

            Console.WriteLine($"ConvertToInt FAILED: '{value}' (Type: {value?.GetType().Name}) -> 0");
            return 0;
        }

        private decimal ConvertToDecimal(object value)
        {
            if (value == null) return 0m;
            if (decimal.TryParse(value.ToString(), out decimal result)) return result;
            return 0m;
        }

        private DateTime ConvertToDateTime(object value)
        {
            if (value == null) return DateTime.MinValue;
            if (DateTime.TryParse(value.ToString(), out DateTime result)) return result;
            return DateTime.MinValue;
        }

        private async Task<bool> ProbarConexionBaseDatos()
        {
            try
            {
                using (var connection = new System.Data.SqlClient.SqlConnection(CapaDatos.SQL.ConexionDB.CadenaConexion))
                {
                    await connection.OpenAsync();
                    Console.WriteLine("✓ Conexión a la base de datos exitosa.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al conectar a la base de datos: {ex.Message}");
                return false;
            }
        }

        private async void btnGuardarLotes_Click(object sender, EventArgs e)
        {
            if (allRows.Count == 0)
            {
                MessageBox.Show("No hay registros para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Configurar ProgressBar inmediatamente antes de iniciar
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Math.Min(300000, allRows.Count);
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            // Actualizar la interfaz para que se muestre el ProgressBar
            Application.DoEvents();

            // Mostrar mensaje de inicio
            MessageBox.Show($"Iniciando guardado de {Math.Min(300000, allRows.Count)} registros en la base de datos...", "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await GuardarPrimeros300000Registros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Los métodos btnCargarMas_Click y btnAdd_Click ya no son necesarios para la paginación con VirtualMode
        // Se pueden eliminar o comentar si no tienen otro propósito.

        //metodo para cargar los datos de SQL
        public void CargarDatos()
        {
            VentasN ventasN = new VentasN();
            dgvExcel.ReadOnly = true;
            dgvExcel.DataSource = ventasN.CargarRoles();
        }
    }


}
