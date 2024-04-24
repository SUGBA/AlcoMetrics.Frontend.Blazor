using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Client.Pages.ProjectsPage.Request;

namespace Client.Pages.ProjectsPage.Models.Request
{
    /// <summary>
    /// Модель создания проекта по всем показателям
    /// </summary>
    public class CreateProjectModelByAllParams : BaseCreateProjectModel
    {
        /// <summary>
        /// Содержание алкоголя
        /// </summary>
        [JsonPropertyName("AlcoholValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public float? AlcoholValue { get; set; }

        /// <summary>
        /// Содрежание сахара
        /// </summary>
        [JsonPropertyName("SugarValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1000, ErrorMessage = "Недостижимое содержание сахара")]
        public float? SugarValue { get; set; }
    }
}
