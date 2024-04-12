namespace Client.Pages.TimeLineDayPage.Models
{
    /// <summary>
    /// Enum выбора способа актуализации показаний
    /// </summary>
    public enum UpdatingMethodEnum : byte
    {
        /// <summary>
        /// Показания ареометра
        /// </summary>
        AreometerValue = 1,

        /// <summary>
        /// Ввод всех показателей
        /// </summary>
        AllIndicators = 2
    }
}
