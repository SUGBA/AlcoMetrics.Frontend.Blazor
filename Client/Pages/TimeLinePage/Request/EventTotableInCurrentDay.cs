namespace Client.Pages.TimeLinePage.Request
{
    /// <summary>
    /// Сущность одного события
    /// </summary>
    public class EventTotableInCurrentday
    {
        /// <summary>
        /// Наименование события
        /// </summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// Тип события
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Завершенность
        /// </summary>
        public string IsReady { get; set; } = string.Empty;
    }
}
