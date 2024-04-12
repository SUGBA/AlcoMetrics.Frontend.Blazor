namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Модель индикатора для текущего дня
    /// </summary>
    public class CurrentDayIndicator
    {
        /// <summary>
        /// Текущая дата
        /// </summary>
        public DateTime CurrentDateTime { get; set; }

        /// <summary>
        /// Объем
        /// </summary>
        public float Wort { get; set; }

        /// <summary>
        /// Процентное содержание спирта
        /// </summary>
        public float EthanolValue { get; set; }

        /// <summary>
        /// Содержание сахара
        /// </summary>
        public float SuagrValue { get; set; }
    }
}
