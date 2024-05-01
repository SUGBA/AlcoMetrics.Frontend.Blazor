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

            //var result = response.StatusCode == System.Net.HttpStatusCode.NoContent ? null : await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();
            //return result;
        }

        public async Task<string?> UpdateDayIndicatorsByAreometerAsync(UpdateIndicatorsByAllAreometer model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var updatePath = WineBackendConfiguration.UpdateByAreometerPath;
            var path = $"{domenPath}/{updatePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
