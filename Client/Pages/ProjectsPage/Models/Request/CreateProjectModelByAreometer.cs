using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1135, ErrorMessage = "Невозможное значение ареометра")]
        public float? AreometerValue { get; set; }
    }
}
