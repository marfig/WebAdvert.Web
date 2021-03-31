using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AdvertApi.Models;

namespace WebAdvert.Web.ServiceClients
{
    public class AdvertApiClient : IAdvertApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public AdvertApiClient(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;

            var createUrl = _configuration.GetSection(key: "AdvertApi").GetValue<string>(key: "CreateUrl");
            _client.BaseAddress = new Uri(createUrl);
            _client.DefaultRequestHeaders.Add(name: "Content-type", value: "application/json");
        }

        public async Task<AdvertResponse> Create(CreateAdvertApiModel model)
        {
            var advertApiModel = new AdvertModel();//Automapper
            var jsonModel = JsonSerializer.Serialize(advertApiModel);
            var response = await _client.PostAsync(_client.BaseAddress, new StringContent(jsonModel));
            var responseJson = await response.Content.ReadAsStringAsync();
            var createAdvertResponse = JsonSerializer.Deserialize<CreateAdvertResponse>(responseJson);
            var advertResponse = new AdvertResponse(); //automapper

            return advertResponse;
        }
    }
}
