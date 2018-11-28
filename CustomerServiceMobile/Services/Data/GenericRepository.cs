using CustomerServiceMobile.Contracts.Data;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomerServiceMobile.Services.Data
{
    public class GenericRepository : IGenericRepository
    {
        public async Task<T> GetAsync<T>(string uri)
        {
            HttpClient httpClient = CreateHttpClient();
            string jsonResult = string.Empty;

            var responseMessage = await httpClient.GetAsync(uri);

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var json = JsonConvert.DeserializeObject<T>(jsonResult);
                return json;
            }

            throw new Exception();
        }

        public async Task PostAsync(string uri, object data)
        {
            HttpClient httpClient = CreateHttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(data));

            var stringContent = await content.ReadAsStringAsync();

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string jsonResult = string.Empty;

            var responseMessage = await httpClient.PostAsync(uri, content);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Created)
            {
                var message = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(message);
            }
        }

        public async Task PutAsync(string uri, object data)
        {
            HttpClient httpClient = CreateHttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string jsonResult = string.Empty;

            var responseMessage = await httpClient.PutAsync(uri, content);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(message);
            }
        }

        public async Task DeleteAsync(string uri)
        {
            HttpClient httpClient = CreateHttpClient();

            var responseMessage = await httpClient.DeleteAsync(uri);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                var message = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(message);
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
