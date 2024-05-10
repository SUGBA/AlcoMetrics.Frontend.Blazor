using System.Text.Json.Serialization;

namespace Client.Pages.SettingGrapeVarietiesPage.Models.Response
{
    /// <summary>
    /// Модель сорта винограда
    /// </summary>
    public class GrapeVarietyResponse
    {
        /// <summary>
        /// Идентификатор записи о сорте винограда
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Название сорта винограда
        /// </summary>
        [JsonPropertyName("GrapeVarietyName")]
        public string GrapeVarietyName { get; set; } = string.Empty;

        /// <summary>
        /// Содержание сахара: г/100см^3
        /// </summary>
        [JsonPropertyName("SugarValue")]
        public double SugarValue { get; set; }

        /// <summary>
        /// Кислотность сорта винограда: г/дм^3
        /// </summary>
        [JsonPropertyName("AcidValue")]
        public double AcidValue { get; set; }

        /// <summary>
        /// Метод клонирования, нужен для таблицы, чтобы ссылки на текущую запись не влияла на искомую запись
        /// </summary>
        /// <returns></returns>
        public GrapeVarietyResponse Clone() => (GrapeVarietyResponse)this.MemberwiseClone();
    }
}
