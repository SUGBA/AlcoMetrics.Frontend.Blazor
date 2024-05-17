using System.Net.Http.Json;
using Client.Configuration.ApiConfiguration;
using Client.Pages.TimeLineDayPage.Request;
using Client.Pages.TimeLineDayPage.Response;

namespace Client.Pages.TimeLineDayPage.Services
{
    /// <summary>
    /// Имплементация сервиса Api для модуля TimeLineDay
    /// </summary>
    public class TimeLineDayApiService : ITimeLineDayApiService
    {
        private readonly HttpClient _httpClient;

        public TimeLineDayApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrentDayIndicatrosResponse> GetCurrentDayIndicatorsAsync(int dayId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getIndicatorsPath = WineBackendConfiguration.GetDayIndicatorsPath;
            var path = $"{domenPath}/{getIndicatorsPath}/{dayId}";

            var response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CurrentDayIndicatrosResponse>() ?? new CurrentDayIndicatrosResponse();
            return new CurrentDayIndicatrosResponse();
        }

        public async Task<IEnumerable<CurrentDayEventsResponse>> GetEventsAsync(int dayId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getEventPath = WineBackendConfiguration.GetDayEventsPath;
            var path = $"{domenPath}/{getEventPath}/{dayId}";

            var response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<CurrentDayEventsResponse>>() ?? Enumerable.Empty<CurrentDayEventsResponse>();
            return Enumerable.Empty<CurrentDayEventsResponse>();
        }

        public async Task<string?> UpdateDayIndicatorsByAllParamsAsync(UpdateIndicatorsByAllParam model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.UpdateByAllParamPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            return null;
        }

        public async Task<string?> UpdateDayIndicatorsByAreometerAsync(UpdateIndicatorsByAllAreometer model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.UpdateByAreometerPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            return null;
        }

        public async Task<CurrentDayEventsResponse?> AddAlcoholizationEventAsync(AddAlcoholizationEvent request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var addEventPath = WineBackendConfiguration.AddAlcoholizationPath;
            var path = $"{domenPath}/{addEventPath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
            return null;
        }

        public async Task<CurrentDayEventsResponse?> AddBlendingEventByAllParamsAsync(AddBlendingEventByAllParams request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.AddBlendingEventByAllParamsPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
            return null;
        }

        public async Task<CurrentDayEventsResponse?> AddBlendingEventByProjectAsync(AddBlendingEventByProject request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.AddBlendingEventByProjectPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
            return null;
        }

        public async Task<CurrentDayEventsResponse?> AddShaptalizationEventAsync(AddShaptalizationEvent request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.AddShaptalizationEvent;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
            return null;
        }

        public async Task<List<GetProjectsResponse>> GetProjectsAsync(int currentProjectId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getProjectsPath = WineBackendConfiguration.GetProjectsForBlendingPath;
            var path = $"{domenPath}/{getProjectsPath}/{currentProjectId}";

            var response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetProjectsResponse>>();
                return result?.ToList() ?? new List<GetProjectsResponse>();
            }
            return new List<GetProjectsResponse>();
        }

        public async Task<bool> AcceptEventAsync(int eventId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var acceptEventPath = WineBackendConfiguration.AcceptEventPath;
            var path = $"{domenPath}/{acceptEventPath}/{eventId}";

            var response = await _httpClient.PostAsync(path, null);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            return false;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var removeEventPath = WineBackendConfiguration.RemoveEventPath;
            var path = $"{domenPath}/{removeEventPath}/{eventId}";

            var response = await _httpClient.PostAsync(path, null);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            return false;
        }
    }
}
