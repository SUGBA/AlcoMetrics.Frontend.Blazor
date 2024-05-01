using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Модель добавления события купажирования путем выбора проекта
    /// </summary>
    public class AddBlendingEventByProject
    {
        /// <summary>
        /// Id выбранного проекта
        /// </summary>
        [JsonPropertyName("SelectedProjectId")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public int SelectedProjectId { get; set; }

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
    }
}
