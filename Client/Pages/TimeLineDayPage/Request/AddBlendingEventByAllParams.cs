using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Модель для добавления события купажирования по всем параметрам
    /// </summary>
    public class AddBlendingEventByAllParams
    {
        /// <summary>
        /// Содержание алкоголя в купаже
        /// </summary>
        [JsonPropertyName("AlcoholValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public float? AlcoholValue { get; set; }

        /// <summary>
        /// Содрежание сахара в купаже
        /// </summary>
        [JsonPropertyName("SugarValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1000, ErrorMessage = "Недостижимое содержание сахара")]
        public float? SugarValue { get; set; }

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
        /// Id дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }
    }
}
