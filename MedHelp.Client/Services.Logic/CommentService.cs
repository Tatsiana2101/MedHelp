using Blazored.LocalStorage;
using MedHelp.Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MedHelp.Client.Services.Logic
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public CommentService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<int> AddComment(Comment comment)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.PostAsJsonAsync("comment", comment);
            var idString = await resp.Content.ReadAsStringAsync();
            var id = int.Parse(idString);

            return id;
        }

        public async Task<List<Comment>> GetCommentsByDoctor(int doctorId)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.GetAsync($"comment/doctor/{doctorId}");
            var commentsString = await resp.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<Comment>>(commentsString);

            return comments;
        }

        public async Task<List<Comment>> GetCommentsByPatient(int patientId)
        {
            var token = await _localStorageService.GetItemAsStringAsync("access_token");

            if (_httpClient.DefaultRequestHeaders.Contains("access_token"))
                _httpClient.DefaultRequestHeaders.Remove("access_token");

            _httpClient.DefaultRequestHeaders.Add("access_token", token);

            var resp = await _httpClient.GetAsync($"comment/patient/{patientId}");
            var commentsString = await resp.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<Comment>>(commentsString);

            return comments;
        }
    }
}
