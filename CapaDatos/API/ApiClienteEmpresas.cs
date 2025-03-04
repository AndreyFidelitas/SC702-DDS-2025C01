using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CapaEntidades;
using CapaEntidades.ApiEmpresarial;
using Newtonsoft.Json;

namespace CapaDatos.API
{
    public class ApiClienteEmpresas
    {
        // Método para consultar la API y devolver los valores mapeados a las entidades
        public static async Task<Response> ConsultarAPI(ClientesE clientes)
        {
            // Definimos la URL
            string url = $"https://api.hacienda.go.cr/fe/ae?identificacion={clientes.Cedula}";

            using (HttpClient client = new HttpClient())
            {
                // Hacemos la solicitud GET
                HttpResponseMessage response = await client.GetAsync(url);

                // Si la respuesta es exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leemos la respuesta JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserializamos la respuesta JSON en un objeto de tipo Response
                    Response data = JsonConvert.DeserializeObject<Response>(jsonResponse);

                    // Devolvemos los datos obtenidos
                    return data;
                }
                else
                {
                    // En caso de error, devolvemos null o puedes crear un objeto Response con un mensaje de error
                    return null;
                }
            }
        }
    }
}
