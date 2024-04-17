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

        private readonly IHttpClientFactory _clientFactory;

        public PasswordAuthorizeAPI(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _clientFactory = httpClientFactory;
        }

        public async Task<string?> Login(string login, string password)
        {
            var domenPath = _configuration.TryGetValue("AuthSetting:AuthenticationServicePath", "Конфигурация не содержит доменный путь до агрегирующего сервиса");
            var loginPath = _configuration.TryGetValue("AuthSetting:LoginPath", "Конфигурация не содержит путь до точки с аутентификацией");
            var httpClientName = _configuration.TryGetValue("ApiSettings:HttpClientName", "Конфигурация не содержит имя HttpClient");
            var path = $"{domenPath}/{loginPath}";

            var httpclient = _clientFactory.CreateClient(httpClientName);

            var response = await httpclient.PostAsJsonAsync(path, new { Login = login, Password = password });

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

        public Task<IEnumerable<string>> Register(string login, string password)
        {
            ///Запрос на регистрацию и получение токена
            throw new NotImplementedException();
        }

    }
}
