namespace Client.SharedComponents.Modal.Models
{
    /// <summary>
    /// Моделька для модалки с отображением информации
    /// </summary>
    public class InfoModalData
    {
        /// <summary>
        /// Заголовок модалки
        /// </summary>
        public string Header { get; set; } = string.Empty;

        /// <summary>
        /// Отображаемые данные
        /// </summary>
        public string[] Data { get; set; } = Array.Empty<string>();
    }
}
