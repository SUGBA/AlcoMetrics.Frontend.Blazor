using Client.Pages.TimeLineDayPage.Request;
using Client.Pages.TimeLineDayPage.Response;

namespace Client.Pages.TimeLineDayPage.Services
{
    /// <summary>
    /// Сервис API для модуля TimeLineDay
    /// </summary>
    public interface ITimeLineDayApiService
    {

        /// <summary>
        /// Получить показатели выбранного дня
        /// </summary>
        /// <param name="dayId"> Id выбранного дня </param>
        /// <returns></returns>
        Task<CurrentDayIndicatrosResponse> GetCurrentDayIndicatorsAsync(int dayId);

        /// <summary>
        /// Получить список мероприятий выбранного дня
        /// </summary>
        /// <param name="dayId"> Id выбранного дня </param>
        /// <returns></returns>
        Task<IEnumerable<CurrentDayEventsResponse>> GetEventsAsync(int dayId);

        /// <summary>
        /// Актуализировать значения текущего дня путем ввода всех параметров
        /// </summary>
        /// <param name="model"> Модель со всеми параметрами и id дня </param>
        /// <returns> Сообщений с ошибкой или Null </returns>
        Task<string?> UpdateDayIndicatorsByAllParamsAsync(UpdateIndicatorsByAllParam model);

        /// <summary>
        /// Актуализировать значения текущего дня путем ввода текущих показаний ареометра
        /// </summary>
        /// <param name="model"> Модель с показаниями ареометра и id дня </param>
        /// <returns> Сообщений с ошибкой или Null </returns>
        Task<string?> UpdateDayIndicatorsByAreometerAsync(UpdateIndicatorsByAllAreometer model);
    }
}
