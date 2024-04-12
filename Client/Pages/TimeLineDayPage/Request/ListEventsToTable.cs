using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Pages.TimeLineDayPage.Request
{
    /// <summary>
    /// Моделька с описанием списка событий в таблицу
    /// </summary>
    public class ListEventsToTable
    {
        /// <summary>
        /// Наименование события
        /// </summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// Тип события
        /// </summary>
        public string EventType { get; set; } = string.Empty;

        /// <summary>
        /// Флаг завершенности
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
