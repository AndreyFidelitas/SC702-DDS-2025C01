using CapaEntidades;
using Newtonsoft.Json;


namespace CapaDatos.API
{
    public class ApiClientes
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<ApiResponse> ObtenerDatosCedulaAsync(int ID)
        {
            try
            {
                // Hacer la solicitud GET a la URL de la API
                HttpResponseMessage response = await client.GetAsync("https://apis.gometa.org/cedulas/"+ID);
                response.EnsureSuccessStatusCode(); // Verificar que la respuesta fue exitosa

                // Leer la respuesta como una cadena
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar el JSON en un objeto de tipo ApiResponse
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                return apiResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al hacer la solicitud: {e.Message}");
                return null;
            }
        }
    }
}
