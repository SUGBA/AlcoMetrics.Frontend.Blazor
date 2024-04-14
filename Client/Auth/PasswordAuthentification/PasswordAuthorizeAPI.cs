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

        public Task<bool> Register(string login, string password)
        {
            ///Запрос на регистрацию и получение токена
            throw new NotImplementedException();
        }

    }
}
