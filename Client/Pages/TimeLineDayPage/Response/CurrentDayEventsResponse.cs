using System.Text.Json.Serialization;

namespace Client.Pages.TimeLineDayPage.Response
{
    /// <summary>
    /// Список мероприятий в выбранном дне, для таблицы в модуле конкретный день
    /// </summary>
    public class CurrentDayEventsResponse
    {
        /// <summary>
        /// Наименование мероприятия
        /// </summary>
        [JsonPropertyName("EventName")]
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// Флаг завершонности мероприятия
        /// </summary>
        [JsonPropertyName("IsReady")]
        public bool IsReady { get; set; }

        /// <summary>
        /// Тип события Пользовательское/Системное
        /// </summary>
        [JsonPropertyName("Type")]
        public string Type { get; set; } = string.Empty;
    }
}
