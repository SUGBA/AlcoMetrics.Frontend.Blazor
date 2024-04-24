using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.ProjectsPage.Request
{
    /// <summary>
    /// Модель создания проекта по сорту винограда
    /// </summary>
    public class CreateProjectModelByGrapeVarety : BaseCreateProjectModel
    {
        /// <summary>
        /// Наименование сорта винограда
        /// </summary>
        [JsonPropertyName("GrapeName")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? GrapeName { get; set; } = null;
    }
}
