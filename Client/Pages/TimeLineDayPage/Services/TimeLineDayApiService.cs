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

            return await response.Content.ReadFromJsonAsync<CurrentDayIndicatrosResponse>() ?? new CurrentDayIndicatrosResponse();
        }

        public async Task<IEnumerable<CurrentDayEventsResponse>> GetEventsAsync(int dayId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getEventPath = WineBackendConfiguration.GetDayEventsPath;
            var path = $"{domenPath}/{getEventPath}/{dayId}";

            var response = await _httpClient.GetAsync(path);

            return await response.Content.ReadFromJsonAsync<IEnumerable<CurrentDayEventsResponse>>() ?? Enumerable.Empty<CurrentDayEventsResponse>();
        }

        public async Task<string?> UpdateDayIndicatorsByAllParamsAsync(UpdateIndicatorsByAllParam model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.UpdateByAllParamPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string?> UpdateDayIndicatorsByAreometerAsync(UpdateIndicatorsByAllAreometer model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.UpdateByAreometerPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<CurrentDayEventsResponse?> AddAlcoholizationEventAsync(AddAlcoholizationEvent request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var addEventPath = WineBackendConfiguration.AddAlcoholizationPath;
            var path = $"{domenPath}/{addEventPath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
        }

        public async Task<CurrentDayEventsResponse?> AddBlendingEventByAllParamsAsync(AddBlendingEventByAllParams request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.AddBlendingEventByAllParamsPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);


            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
        }

        public async Task<CurrentDayEventsResponse?> AddBlendingEventByProjectAsync(AddBlendingEventByProject request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.AddBlendingEventByProjectPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);


            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
        }

        public async Task<CurrentDayEventsResponse?> AddShaptalizationEventAsync(AddShaptalizationEvent request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.AddShaptalizationEvent;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);


            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            return await response.Content.ReadFromJsonAsync<CurrentDayEventsResponse>();
        }

        public async Task<List<GetProjectsResponse>> GetProjectsAsync(int currentProjectId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getProjectsPath = WineBackendConfiguration.GetProjectsForBlendingPath;
            var path = $"{domenPath}/{getProjectsPath}/{currentProjectId}";

            var response = await _httpClient.GetAsync(path);

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetProjectsResponse>>();
            return result?.ToList() ?? new List<GetProjectsResponse>();
        }

        public async Task<bool> AcceptEventAsync(int eventId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var acceptEventPath = WineBackendConfiguration.AcceptEventPath;
            var path = $"{domenPath}/{acceptEventPath}/{eventId}";

            var response = await _httpClient.PostAsync(path, null);

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var removeEventPath = WineBackendConfiguration.RemoveEventPath;
            var path = $"{domenPath}/{removeEventPath}/{eventId}";

            var response = await _httpClient.PostAsync(path, null);

            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
