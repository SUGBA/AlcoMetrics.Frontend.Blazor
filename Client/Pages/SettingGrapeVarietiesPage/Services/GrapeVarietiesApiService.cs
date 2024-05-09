using System.Net.Http.Json;
using Client.Configuration.ApiConfiguration;
using Client.Pages.SettingGrapeVarietiesPage.Models;

namespace Client.Pages.SettingGrapeVarietiesPage.Services
{
    /// <summary>
    /// Имплементация сервиса API для редактирования сортов винограад
    /// </summary>
    public class GrapeVarietiesApiService : IGrapeVarietiesApiService
    {
        private readonly HttpClient _httpClient;

        public GrapeVarietiesApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddGrapeVarietyAsync(GrapeVarietyResponse model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var addGrapePath = WineBackendConfiguration.AddAdminGrapeVarietyPath;
            var path = $"{domenPath}/{addGrapePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<List<GrapeVarietyResponse>> GetGrapeVarieties()
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getGrapeVarieties = WineBackendConfiguration.GetGrapeVarietiesPath;
            var path = $"{domenPath}/{getGrapeVarieties}";

            var response = await _httpClient.GetAsync(path);

            return await response.Content.ReadFromJsonAsync<List<GrapeVarietyResponse>>() ?? new();
        }

        public async Task<bool> UpdateGrapeVariety(GrapeVarietyResponse model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updategrapePath = WineBackendConfiguration.UpdateAdminGrapeVarietiesPath;
            var path = $"{domenPath}/{updategrapePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
