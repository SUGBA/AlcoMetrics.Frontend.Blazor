﻿using System.Text.Json.Serialization;

namespace Client.Pages.ProjectsPage.Models.Request
{
    /// <summary>
    /// Модель изменения имени проекта
    /// </summary>
    public class ChangeProjectNameRequest
    {
        /// <summary>
        /// Id изменяемого проекта
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Новое имя проекта
        /// </summary>
        [JsonPropertyName("ProjectName")]
        public string NewProjectName { get; set; } = string.Empty;
    }
}