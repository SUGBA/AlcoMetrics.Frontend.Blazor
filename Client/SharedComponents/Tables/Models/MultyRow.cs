namespace Client.SharedComponents.Tables.Models
{
    /// <summary>
    /// Строка, элементы которой могут распологаться в несколько строк.
    /// То есть одна строка, ячейка которой разбита на несколько строк
    /// </summary>
    public class MultyRow
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ячейки
        /// </summary>
        public List<List<string>> Cells { get; set; } = new();
    }
}
