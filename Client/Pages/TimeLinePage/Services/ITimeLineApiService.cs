using Client.Pages.TimeLinePage.Response;

namespace Client.Pages.TimeLinePage.Services
{
    /// <summary>
    /// Сервис для работы с TimeLinePage
    /// </summary>
    public interface ITimeLineApiService
    {
        /// <summary>
        /// Получить список дней в проекте
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<DayIndicators>> GetDays(int projectId);
    }
}
