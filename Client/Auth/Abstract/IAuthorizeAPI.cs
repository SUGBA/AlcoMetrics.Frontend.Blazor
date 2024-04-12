namespace Client.Auth.Abstract
{
    /// <summary>
    /// Компонент для отправки аутентификационных сообщений
    /// </summary>
    public interface IAuthorizeAPI
    {
        /// <summary>
        /// Аутентификация
        /// </summary>
        /// <param name="login"> Логин пользователя </param>
        /// <param name="password"> Пароль пользователя </param>
        /// <returns> True - Успех/False - провал </returns>
        Task<bool> Login(string login, string password);

        /// <summary>
        /// Выйти из системы
        /// </summary>
        /// <returns></returns>
        Task Logout();

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="login"> Логин пользователя </param>
        /// <param name="password"> Пароль пользователя </param>
        /// <returns> True - Успех/False - провал </returns>
        Task<bool> Register(string login, string password);
    }
}
