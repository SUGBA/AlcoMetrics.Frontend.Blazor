namespace Client.SharedComponents.Tables.Models
{
    /// <summary>
    /// Строка таблицы
    /// </summary>
    public class Row
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ячейки
        /// </summary>
        public List<string> Cells { get; set; } = new();
    }
}
