using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Pages.SettingGrapeVarietiesPage.Models.Request
{
    /// <summary>
    /// Модель сорта винограда
    /// </summary>
    public class GrapeVarietyRequest
    {
        /// <summary>
        /// Идентификатор записи о сорте винограда
        /// </summary>
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        /// <summary>
        /// Название сорта винограда
        /// </summary>
        [JsonPropertyName("GrapeVarietyName")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string GrapeVarietyName { get; set; } = string.Empty;

        /// <summary>
        /// Содержание сахара: г/100см^3
        /// </summary>
        [JsonPropertyName("SugarValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public double? SugarValue { get; set; }

        /// <summary>
        /// Кислотность сорта винограда: г/дм^3
        /// </summary>
        [JsonPropertyName("AcidValue")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public double? AcidValue { get; set; }
    }
}
