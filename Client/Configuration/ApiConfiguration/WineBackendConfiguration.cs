namespace Client.Configuration.ApiConfiguration
{
    /// <summary>
    /// Конфигурация для настройки API для бэкэнда виноделия
    /// </summary>
    public class WineBackendConfiguration
    {
        /// <summary>
        /// Доменный путь до сервиса виноделия
        /// </summary>
        public static string DomenPath = "https://localhost:5003";

        #region ProjectPage

        /// <summary>
        /// Точка для изменении имени проекта
        /// </summary>
        public static string ChangeProjectNamePath = "ProjectsPage/ChangeProjectName";

        /// <summary>
        /// Точка для получения списка проектов пользователя
        /// </summary>
        public static string GetProjectsPath = "ProjectsPage/GetProjects";

        /// <summary>
        /// Точка для получения удаления проекта пользователя
        /// </summary>
        public static string DeleteProjectPath = "ProjectsPage/DeleteProject";

        /// <summary>
        /// Точка для создание проекта путем ввода всех параметров
        /// </summary>
        public static string CreateProjectByAllParamasPath = "ProjectsPage/CreateTimeLineByAllParams";

        /// <summary>
        /// Точка для создание проекта путем ввода показания ареометра
        /// </summary>
        public static string CreateProjectByAreometerPath = "ProjectsPage/CreateTimeLineByAreometer";

        /// <summary>
        /// Точка для создание проекта путем ввода всех параметров
        /// </summary>
        public static string CreateProjectByGrapeVaretyPath = "ProjectsPage/CreateTimeLineByGrapeVarety";

        /// <summary>
        /// Точка для получения списка сортов винограда
        /// </summary>
        public static string GetGrapeVarietiesPath = "ProjectsPage/GetGrapeVarieties";

        #endregion
    }
}
