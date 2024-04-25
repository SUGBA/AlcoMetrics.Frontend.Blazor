using System.Net.Http.Json;
using Client.Configuration.ApiConfiguration;
using Client.Pages.TimeLinePage.Response;

namespace Client.Pages.TimeLinePage.Services
{
    /// <summary>
    /// Имплементация сервиса работы со страницей ITimeLineService
    /// </summary>
    public class TimeLineApiService : ITimeLineApiService
    {
        private readonly HttpClient _httpClient;

        public TimeLineApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Получить список дней в проекте
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DayIndicators>> GetDays(int projectId)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getDaysPath = WineBackendConfiguration.GetDaysPath;
            var path = $"{domenPath}/{getDaysPath}/{projectId}";

            var response = await _httpClient.GetAsync(path);

            return await response.Content.ReadFromJsonAsync<IEnumerable<DayIndicators>>() ?? Enumerable.Empty<DayIndicators>();
        }
    }
}
