namespace Client.Auth.Abstract
{
    /// <summary>
    /// Сервис для работы с JWT токенами
    /// </summary>
    public interface ITokenProviderService
    {
        /// <summary>
        /// Получить значение из JWT токена
        /// </summary>
        /// <param name="token"> Токен </param>
        /// <param name="key"> Значение ключа </param>
        /// <returns></returns>
        public string? GetValue(string token, string key);

        /// <summary>
        /// Получить значения из JWT токена
        /// </summary>
        /// <param name="token"> Токен </param>
        /// <param name="key"> Значение ключа </param>
        /// <returns></returns>
        public List<string>? GetValues(string token, string key);
    }
}
