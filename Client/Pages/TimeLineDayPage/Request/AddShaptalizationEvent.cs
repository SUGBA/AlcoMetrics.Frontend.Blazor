using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Модель добавления события шаптализация
    /// </summary>
    public class AddShaptalizationEvent
    {
        /// <summary>
        /// Желаемое содрежание сахара
        /// </summary>
        [JsonPropertyName("DesiredSugarValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1000, ErrorMessage = "Недостижимое содержание сахара")]
        public float? DesiredSugarValue { get; set; } = null;

        /// <summary>
        /// Id дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }
    }
}
