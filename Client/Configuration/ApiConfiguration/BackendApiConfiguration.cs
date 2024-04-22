namespace Client.Configuration.ApiConfiguration
{
    /// <summary>
    /// Конфигурация для настройки API для агрегационного бэкэнда
    /// </summary>
    public class BackendApiConfiguration
    {
        /// <summary>
        /// Доменный путь до агрегирующего сервиса
        /// </summary>
        public static string DomenPath = "https://localhost:5002";

        #region Auth

        /// <summary>
        /// Конечная точка для входа в систему
        /// </summary>
        public static string LoginPath = "Account/Login";

        /// <summary>
        /// Конечная точка для регистрации
        /// </summary>
        public static string RegisterPath = "Account/RegisterUser";

        #endregion
    }
}
