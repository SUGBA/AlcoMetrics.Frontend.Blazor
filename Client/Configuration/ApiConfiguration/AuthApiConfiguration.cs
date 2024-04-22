namespace Client.Configuration.ApiConfiguration
{
    /// <summary>
    /// Конфигурация для настройки API для авторизационного сервиса
    /// </summary>
    public static class AuthApiConfiguration
    {
        /// <summary>
        /// Имя переменной для хранения токена в localStorage
        /// </summary>
        public static string TokenVariableName = "token";

        /// <summary>
        /// Имя для HttpClient
        /// </summary>
        public static string ApiName = "Wine Analyzer Web User";
    }
}
