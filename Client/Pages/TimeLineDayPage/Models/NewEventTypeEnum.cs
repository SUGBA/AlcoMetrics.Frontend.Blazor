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
        /// Купажирование на основе всех параметров
        /// </summary>
        BlendingByAllParams = 2,

        /// <summary>
        /// Купажирование на основе выбора проекта
        /// </summary>
        BlendingByProject = 3,

        /// <summary>
        /// Крепление
        /// </summary>
        Alcoholization = 4
    }
}
