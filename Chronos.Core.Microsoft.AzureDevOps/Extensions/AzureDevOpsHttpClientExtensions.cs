using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Chronos.Core.Microsoft.AzureDevOps.Extensions
{
    public static class AzureDevOpsHttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string accessToken, string uri)
        {
            T result = default;
            await httpClient.GetAsync(accessToken, uri, async content =>
            {
                var stringContent = await content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<T>(stringContent);
            });

            return result;
        }

        private static async Task GetAsync(this HttpClient httpClient, string accessToken, string uri, Func<HttpContent, Task> @do)
        {
            Debug.WriteLine($"GetAsync({uri})");
            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{""}:{accessToken}")));

            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            await @do(response.Content);
        }
    }
}