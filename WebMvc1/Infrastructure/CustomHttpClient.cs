using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvc1.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public CustomHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetStringAsync(string uri,
            string authorizationToken = null,
            string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            //look into sendasync
            Debug.WriteLine("*** REQUEST URI ***: " + requestMessage.RequestUri);
            var response = await _client.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();

        }
    }
}
