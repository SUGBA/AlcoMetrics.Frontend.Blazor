using System.ComponentModel.DataAnnotations;

namespace Client.Pages.AuthPage.Models
{
    /// <summary>
    /// Модель для авторизации
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string? Password { get; set; }
    }
}
