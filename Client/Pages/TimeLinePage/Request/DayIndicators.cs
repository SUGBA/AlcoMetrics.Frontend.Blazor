namespace Client.Pages.TimeLinePage.Request
{
    /// <summary>
    /// Моделька с показателями конкретного дня
    /// </summary>
    public class DayIndicators
    {
        /// <summary>
        /// Номер дня
        /// </summary>
        public byte DayNumber { get; set; }

        /// <summary>
        /// Месяц
        /// </summary>
        public string Month { get; set; } = string.Empty;

        /// <summary>
        /// Содержание спирта
        /// </summary>
        public float EthanolValue { get; set; }

        /// <summary>
        /// Содержание сахара
        /// </summary>
        public float SugarValue { get; set; }

        /// <summary>
        /// Количество событий
        /// </summary>
        public int EventCount { get; set; }
    }
}
