using System.ComponentModel.DataAnnotations;

namespace Client.Pages.ProjectsPage.Request
{
    /// <summary>
    /// Базовая модель для создания проекта
    /// </summary>
    public abstract class BaseCreateProjectModel
    {
        /// <summary>
        /// Наименование проекта
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? ProjectName { get; set; } = null;

        /// <summary>
        /// Желаемое содержание алкоголя
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public float? DesiredAlcoholValue { get; set; } = null;

        /// <summary>
        /// Желаемое содрежание сахара
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1000, ErrorMessage = "Недостижимое содержание сахара")]
        public float? DesiredSugarValue { get; set; } = null;

        /// <summary>
        /// Объем сусла
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Недопустимый объем сусла")]
        public float? Wort { get; set; } = null;
    }
}
