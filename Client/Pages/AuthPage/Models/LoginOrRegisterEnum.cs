namespace Client.Pages.AuthPage.Models
{
    /// <summary>
    /// Моделька с описанием регистрация это или вход
    /// </summary>
    public enum LoginOrRegisterEnum:byte
    {
        /// <summary>
        /// Вход
        /// </summary>
        Login = 1,
        
        /// <summary>
        /// Регистрация
        /// </summary>
        Register = 2
    }
}
