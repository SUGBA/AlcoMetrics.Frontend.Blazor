using System.ComponentModel.DataAnnotations;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Обновление показателей путем ввода значения ареометра
    /// </summary>
    public class UpdateIndicatorsByAllAreometer
    {
        /// <summary>
        /// Показание ареометра
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1135, ErrorMessage = "Невозможное значение ареометра")]
        public int? AreometerValue { get; set; }
    }
}
