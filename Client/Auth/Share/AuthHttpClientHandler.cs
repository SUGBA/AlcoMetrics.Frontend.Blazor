using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using Client.Extensions;
using Microsoft.Extensions.Configuration;

namespace Client.Auth.Share
{
    /// <summary>
    /// Обработчик Http запросов
    /// Все запросых проходят через этот компонент
    /// </summary>
    public class AuthHttpClientHandler : DelegatingHandler
    {
        private readonly IConfiguration _configuration;

        private readonly ILocalStorageService _localStorageService;

        private readonly NavigationManager _navigationManager;

        public AuthHttpClientHandler(IConfiguration configuration,
            ILocalStorageService localStorageService,
            NavigationManager navigationManager)
        {
            _configuration = configuration;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            await CorrectAfter401Result(response);

            return response;
        }

        /// <summary>
        /// Сбрасываем токен из хранилища поскольку он больше не является валидным
        /// Статусный код 401 характеризует его невалидность
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task CorrectAfter401Result(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var tokenVariableName = _configuration.TryGetValue("AuthSetting:TokenVariableName", "Конфигурация не содержит наименования переменной с полем. Ошибка при обработке не авторизованного пользователя.");
                await _localStorageService.RemoveItemAsync(tokenVariableName);
                _navigationManager.NavigateTo("/auth", forceLoad: true);
            }
        }
    }
}
