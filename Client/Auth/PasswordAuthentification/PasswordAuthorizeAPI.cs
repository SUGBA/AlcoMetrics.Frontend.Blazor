using System.Net.Http.Json;
using Client.Auth.PasswordAuthentification.Abstract;
using Client.Configuration.ApiConfiguration;

namespace Client.Auth.PasswordAuthentification
{
    /// <summary>
    /// Класс для отправки аутентификационных сообщений
    /// </summary>
    public class PasswordAuthorizeAPI : IAuthorizeAPI
    {
        private static string REGISTER_API_ERROR = "Ошибка при регистрации. Возможно сервис недоступен. Попробуйте позже";

        private readonly HttpClient _httpClient;

        public PasswordAuthorizeAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> Login(string login, string password)
        {
            var domenPath = BackendApiConfiguration.DomenPath;
            var loginPath = BackendApiConfiguration.LoginPath;
            var path = $"{domenPath}/{loginPath}";

            var response = await _httpClient.PostAsJsonAsync(path, new { Login = login, Password = password });

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                return null;
        }

        /// <summary>
        /// Регистрация пользователя
        /// На выход приходит массив с ошибками
        /// Если ошибок нету, но код http не положительный, добалвяем ошибку
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> Register(string login, string password)
        {
            var domenPath = BackendApiConfiguration.DomenPath;
            var registerPath = BackendApiConfiguration.RegisterPath;
            var path = $"{domenPath}/{registerPath}";

            var response = await _httpClient.PostAsJsonAsync(path, new { Login = login, Password = password });
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.IsSuccessStatusCode)    //В этих случаях нам точно отправили в теле ответ (пускай и пустой массив)
                return await response.Content.ReadFromJsonAsync<IEnumerable<string>>() ?? Enumerable.Empty<string>();

            if (!response.IsSuccessStatusCode)
                return new List<string>() { REGISTER_API_ERROR };

            return Enumerable.Empty<string>();
        }
    }
}
