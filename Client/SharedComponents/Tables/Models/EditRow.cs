namespace Client.SharedComponents.Tables.Models
{
    /// <summary>
    /// Модель изменяемой строки
    /// </summary>
    public class EditRow
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Новое значение проекта
        /// </summary>
        public string UpdatedName { get; set; } = string.Empty;
    }
}
