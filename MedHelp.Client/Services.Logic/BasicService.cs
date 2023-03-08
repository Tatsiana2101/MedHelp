using Blazored.LocalStorage;
using MedHelp.Client.Models;
using Newtonsoft.Json;

namespace MedHelp.Client.Services.Logic
{
    public class BasicService : IBasicService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public BasicService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<List<Sex>> GetAllSexes()
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.GetAsync("auth/sexes");
            var sexesString = await resp.Content.ReadAsStringAsync();
            var sexes = JsonConvert.DeserializeObject<List<Sex>>(sexesString);

            return sexes;
        }
    }
}
