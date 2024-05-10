using System.Net.Http.Json;
using Client.Configuration.ApiConfiguration;
using Client.Pages.SettingGrapeVarietiesPage.Models.Response;

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

        public async Task<GrapeVarietyResponse> AddGrapeVarietyAsync(GrapeVarietyResponse model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var addGrapePath = WineBackendConfiguration.AddAdminGrapeVarietyPath;
            var path = $"{domenPath}/{addGrapePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<GrapeVarietyResponse>() ?? new();
            return new GrapeVarietyResponse();
        }

        public async Task<List<GrapeVarietyResponse>> GetGrapeVarieties()
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getGrapeVarieties = WineBackendConfiguration.GetAdminGrapeVarietiesPath;
            var path = $"{domenPath}/{getGrapeVarieties}";

            var response = await _httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<GrapeVarietyResponse>>() ?? new();
            return new List<GrapeVarietyResponse>();
        }

        public async Task<bool> RemoveGrapeVarietyAsync(int id)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var removeGrapePath = WineBackendConfiguration.RemoveAdminGrapeVarietyPath;
            var path = $"{domenPath}/{removeGrapePath}/{id}";

            var response = await _httpClient.PostAsync(path, null);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            return false;
        }

        public async Task<bool> UpdateGrapeVariety(GrapeVarietyResponse model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updategrapePath = WineBackendConfiguration.UpdateAdminGrapeVarietiesPath;
            var path = $"{domenPath}/{updategrapePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            return false;
        }
    }
}
