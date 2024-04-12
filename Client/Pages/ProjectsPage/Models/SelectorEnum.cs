namespace Client.Pages.ProjectsPage.Models
{
    /// <summary>
    /// Enum со способами создания проекта
    /// </summary>
    public enum SelectorEnum
    {
        /// <summary>
        /// По всем параметрам
        /// </summary>
        ByAllParams = 0,

        /// <summary>
        /// По показаниям ареометра
        /// </summary>
        ByAreometer = 1,

        /// <summary>
        /// По сорты винограда
        /// </summary>
        ByGrapeVarety = 2
    }
}
