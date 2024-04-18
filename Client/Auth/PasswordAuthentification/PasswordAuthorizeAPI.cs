using System.Data.SqlTypes;
using System.Net.Http.Json;
using Client.Auth.PasswordAuthentification.Abstract;
using Client.Extensions;

namespace Client.Auth.PasswordAuthentification
{
    /// <summary>
    /// Класс для отправки аутентификационных сообщений
    /// </summary>
    public class PasswordAuthorizeAPI : IAuthorizeAPI
    {
        private static string REGISTER_API_ERROR = "Ошибка при регистрации. Возможно сервис недоступен. Попробуйте позже";

        private readonly IConfiguration _configuration;

        private readonly HttpClient _httpClient;

        public PasswordAuthorizeAPI(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<string?> Login(string login, string password)
        {
            var domenPath = _configuration.TryGetValue("AuthSetting:AuthenticationServicePath", "Конфигурация не содержит доменный путь до агрегирующего сервиса");
            var loginPath = _configuration.TryGetValue("AuthSetting:LoginPath", "Конфигурация не содержит путь до точки с аутентификацией");
            var path = $"{domenPath}/{loginPath}";

            var response = await _httpClient.PostAsJsonAsync(path, new { Login = login, Password = password });

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                return null;
        }

        public Task Logout()
        {
            ///Запрос на выход
            throw new NotImplementedException();
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
            var domenPath = _configuration.TryGetValue("AuthSetting:AuthenticationServicePath", "Конфигурация не содержит доменный путь до агрегирующего сервиса");
            var registerPath = _configuration.TryGetValue("AuthSetting:RegisterPath", "Конфигурация не содержит путь до точки с регистрацией");
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
