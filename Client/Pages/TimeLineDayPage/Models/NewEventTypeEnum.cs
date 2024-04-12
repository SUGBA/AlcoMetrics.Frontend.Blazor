namespace Client.Pages.TimeLineDayPage.Models
{
    /// <summary>
    /// Типы добавляемых событий
    /// </summary>
    public enum NewEventTypeEnum : byte
    {
        /// <summary>
        /// Шаптализация
        /// </summary>
        Shaptalization = 1,

        /// <summary>
        /// Купажирование
        /// </summary>
        Blending = 2,

        /// <summary>
        /// Крепление
        /// </summary>
        Alcoholization = 3
    }
}
