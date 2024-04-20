using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeekShoppingWeb.Utils
{
    /// <summary>
    /// Implementação de Http CLient Extensions
    /// </summary>
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw
                    new ApplicationException($"Something went wrong calling the API {response.ReasonPhrase}");
            }
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var retorno = JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return retorno;
        }

        /// <summary>
        /// Implementação de Post Json
        /// </summary>
        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpClient.PutAsync(url, content);
        }

    }
}
