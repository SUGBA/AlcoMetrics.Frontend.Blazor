using System.ComponentModel.DataAnnotations;

namespace Client.Pages.AuthPage.Models
{
    /// <summary>
    /// Моделька для регистрации
    /// </summary>
    public class RegisterModel : LoginModel
    {
        /// <summary>
        /// Повторение пароля
        /// </summary>
        [Required(ErrorMessage ="Поле обязательно к заполнению")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string? RepeatPassword { get; set; }
    }
}
