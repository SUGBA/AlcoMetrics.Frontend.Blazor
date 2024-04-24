using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.ProjectsPage.Request
{
    /// <summary>
    /// Модель создания проекта по показаниям ареометра
    /// </summary>
    public class CreateProjectModelByAreometer : BaseCreateProjectModel
    {
        /// <summary>
        /// Показания Ареометра
        /// </summary>
        [JsonPropertyName("AreometerValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1135, ErrorMessage = "Невозможное значение ареометра")]
        public int? AreometerValue { get; set; }
    }
}
