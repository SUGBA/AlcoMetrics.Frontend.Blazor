using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using Client.Configuration.ApiConfiguration;
using System.Net.Http.Headers;
using Microsoft.Net.Http.Headers;

namespace Client.Auth.Share
{
    /// <summary>
    /// Обработчик Http запросов
    /// Все запросых проходят через этот компонент
    /// </summary>
    public class AuthHttpClientHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;

        private readonly NavigationManager _navigationManager;

        public AuthHttpClientHandler(ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await SetTokenToRequest(request);

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
                var tokenVariableName = AuthApiConfiguration.TokenVariableName;
                await _localStorageService.RemoveItemAsync(tokenVariableName);
                _navigationManager.NavigateTo("/auth", forceLoad: true);
            }
        }

        /// <summary>
        /// Установить токен в случае его существования каждый запрос из LocalStorage
        /// </summary>
        /// <param name="request"> Запрос </param>
        /// <returns></returns>
        private async Task SetTokenToRequest(HttpRequestMessage request)
        {
            var tokenVariableName = AuthApiConfiguration.TokenVariableName;
            var token = await _localStorageService.GetItemAsync<string>(tokenVariableName);

            if (token != null)
                request.Headers.Add(HeaderNames.Authorization, $"Bearer {token}");
        }
    }
}
