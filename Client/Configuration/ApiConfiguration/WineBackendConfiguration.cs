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
        public static string ChangeProjectNamePath = "Projects/ChangeProjectName";

        /// <summary>
        /// Точка для получения списка проектов пользователя
        /// </summary>
        public static string GetProjectsPath = "Projects/GetProjects";

        /// <summary>
        /// Точка для получения удаления проекта пользователя
        /// </summary>
        public static string DeleteProjectPath = "Projects/DeleteProject";

        /// <summary>
        /// Точка для создание проекта путем ввода всех параметров
        /// </summary>
        public static string CreateProjectByAllParamasPath = "Projects/CreateTimeLineByAllParams";

        /// <summary>
        /// Точка для создание проекта путем ввода показания ареометра
        /// </summary>
        public static string CreateProjectByAreometerPath = "Projects/CreateTimeLineByAreometer";

        /// <summary>
        /// Точка для создание проекта путем ввода всех параметров
        /// </summary>
        public static string CreateProjectByGrapeVaretyPath = "Projects/CreateTimeLineByGrapeVarety";

        /// <summary>
        /// Точка для получения списка сортов винограда
        /// </summary>
        public static string GetGrapeVarietiesPath = "Projects/GetGrapeVarieties";

        #endregion

        #region TimeLine

        /// <summary>
        /// Точка для получения списка дней проекта
        /// </summary>
        public static string GetDaysPath = "TimeLine/GetDays";

        #endregion

        #region TimeLineDay

        /// <summary>
        /// Точка получения показателей выбранного дня
        /// </summary>
        public static string GetDayIndicatorsPath = "TimeLineDay/GetIndicators";

        /// <summary>
        /// Точка получения событий выбранного дня
        /// </summary>
        public static string GetDayEventsPath = "TimeLineDay/GetEvents";

        /// <summary>
        /// Точка для актуализации показаний на основе всех параметров
        /// </summary>
        public static string UpdateByAllParamPath = "TimeLineDay/UpdateByAllParam";

        /// <summary>
        /// Точка для актуализации показаний на основе показаний ареометра
        /// </summary>
        public static string UpdateByAreometerPath = "TimeLineDay/UpdateByAreometer";

        #endregion
    }
}
