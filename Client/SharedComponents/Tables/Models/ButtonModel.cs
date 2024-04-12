using Microsoft.AspNetCore.Components;

namespace Client.SharedComponents.Tables.Models
{
    /// <summary>
    /// Описание функционала кнопки
    /// </summary>
    public class ButtonModel
    {
        /// <summary>
        /// Содержимое кнопки
        /// </summary>
        public string Content { get; set; } = "Click me";

        /// <summary>
        /// Обработчик события нажатия кнопки (Передается id строки)
        /// </summary>
        public EventCallback<int> CLickButton { get; set; }
    }
}
