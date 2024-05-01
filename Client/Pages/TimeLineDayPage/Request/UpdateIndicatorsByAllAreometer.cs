using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Обновление показателей путем ввода значения ареометра
    /// </summary>
    public class UpdateIndicatorsByAllAreometer
    {
        /// <summary>
        /// Показание ареометра
        /// </summary>
        [JsonPropertyName("AreometerValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, 1135, ErrorMessage = "Невозможное значение ареометра")]
        public int? AreometerValue { get; set; }

        /// <summary>
        /// Id выбранного дня
        /// </summary>
        [JsonPropertyName("DayId")]
        public int DayId { get; set; }
    }
}
