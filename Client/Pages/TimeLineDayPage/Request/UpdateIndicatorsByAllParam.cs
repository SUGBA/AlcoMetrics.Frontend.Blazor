using System.ComponentModel.DataAnnotations;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Обновление показателей путем ввода всех параметров
    /// </summary>
    public class UpdateIndicatorsByAllParam
    {
        /// <summary>
        /// Объем
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Недопустимый объем сусла")]
        public double? Wort { get; set; }

        /// <summary>
        /// Процент алкоголя
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public double? AlcoholPercentage { get; set; }

        /// <summary>
        /// Содержание сахара
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1000, ErrorMessage = "Недостижимое содержание сахара")]
        public double? SugarValue { get; set; }
    }
}
