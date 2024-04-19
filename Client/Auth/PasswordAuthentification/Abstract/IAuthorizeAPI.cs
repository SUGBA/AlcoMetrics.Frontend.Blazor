namespace Client.Auth.PasswordAuthentification.Abstract
{
    /// <summary>
    /// Компонент для отправки аутентификационных сообщений
    /// </summary>
    public interface IAuthorizeAPI
    {
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="login"> Логин пользователя </param>
        /// <param name="password"> Пароль пользователя </param>
        /// <returns> True - Успех/False - провал </returns>
        Task<IEnumerable<string>> Register(string login, string password);

        /// <summary>
        /// Войти и получить токен
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns></returns>
        public Task<string?> Login(string login, string password);
    }
}
