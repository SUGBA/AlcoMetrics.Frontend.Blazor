using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Модель для создания события крепления
    /// </summary>
    public class AddAlcoholizationEvent
    {
        /// <summary>
        /// Желаемое содержание алкоголя
        /// </summary>
        [JsonPropertyName("DesiredAlcoholValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public float? DesiredAlcoholValue { get; set; } = null;

        /// <summary>
        /// Крепость спирта
        /// </summary>
        [JsonPropertyName("AlcoholValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 100, ErrorMessage = "Недостижимое содержание спирта")]
        public float? AlcoholValue { get; set; }
    }
}
