using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? GrapeName { get; set; } = null;
    }
}
