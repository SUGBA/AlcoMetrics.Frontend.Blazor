using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("ProjectName")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? ProjectName { get; set; } = null;

        /// <summary>
        /// Желаемое содержание алкоголя
        /// </summary>
        [JsonPropertyName("DesiredAlcoholValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public float? DesiredAlcoholValue { get; set; } = null;

        /// <summary>
        /// Желаемое содрежание сахара
        /// </summary>
        [JsonPropertyName("DesiredSugarValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1000, ErrorMessage = "Недостижимое содержание сахара")]
        public float? DesiredSugarValue { get; set; } = null;

        /// <summary>
        /// Объем сусла
        /// </summary>
        [JsonPropertyName("Wort")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Недопустимый объем сусла")]
        public float? Wort { get; set; } = null;
    }
}
