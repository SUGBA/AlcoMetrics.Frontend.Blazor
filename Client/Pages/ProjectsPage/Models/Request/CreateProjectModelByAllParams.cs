using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public float? AlcoholValue { get; set; }

        /// <summary>
        /// Содрежание сахара
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1000, ErrorMessage = "Недостижимое содержание сахара")]
        public float? SugarValue { get; set; }
    }
}
