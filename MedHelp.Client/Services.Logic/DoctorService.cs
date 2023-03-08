using Blazored.LocalStorage;
using MedHelp.Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MedHelp.Client.Services.Logic
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public DoctorService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<int> AddDoctor(Doctor doctor)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.PostAsJsonAsync("doctor", doctor);
            var idString = await resp.Content.ReadAsStringAsync();
            var id = int.Parse(idString);

            return id;
        }

        public async Task<int> DeleteDoctor(int id)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.DeleteAsync($"doctor/{id}");
            var idDString = await resp.Content.ReadAsStringAsync();
            var idD = int.Parse(idDString);

            return idD;
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.GetAsync("doctor");
            var doctorsString = await resp.Content.ReadAsStringAsync();
            var doctors = JsonConvert.DeserializeObject<List<Doctor>>(doctorsString);

            return doctors;
        }

        public async Task<int> UpdateDoctor(Doctor doctor)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.PutAsJsonAsync("doctor", doctor);
            var idString = await resp.Content.ReadAsStringAsync();
            var id = int.Parse(idString);

            return id;
        }

        public async Task<List<Tolon>> GetTolones(int doctorId)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.GetAsync($"doctor/tolon/{doctorId}");
            var tolonesString = await resp.Content.ReadAsStringAsync();
            var tolones = JsonConvert.DeserializeObject<List<Tolon>>(tolonesString);

            return tolones;
        }

        public async Task<int> AddTolon(Tolon tolon)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.PostAsJsonAsync("doctor/tolon", tolon);
            var idString = await resp.Content.ReadAsStringAsync();
            var id = int.Parse(idString);

            return id;
        }

        public async Task<int> DeleteTolon(int id)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.DeleteAsync($"doctor/tolon/{id}");
            var idDString = await resp.Content.ReadAsStringAsync();
            var idD = int.Parse(idDString);

            return idD;
        }

        public async Task<Tolon> GetTolon(int id)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.GetAsync($"doctor/tolon/tolonId/{id}");
            var tolonString = await resp.Content.ReadAsStringAsync();
            var tolon = JsonConvert.DeserializeObject<Tolon>(tolonString);

            return tolon;
        }

        public async Task<int> AddReception(Reception reception)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.PostAsJsonAsync("doctor/reception", reception);
            var idString = await resp.Content.ReadAsStringAsync();
            var id = int.Parse(idString);

            return id;
        }

        public async Task<List<Reception>> GetReceptions(int doctorId)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.GetAsync($"doctor/reception/{doctorId}");
            var receptionsString = await resp.Content.ReadAsStringAsync();
            var receptions = JsonConvert.DeserializeObject<List<Reception>>(receptionsString);

            return receptions;
        }
    }
}
