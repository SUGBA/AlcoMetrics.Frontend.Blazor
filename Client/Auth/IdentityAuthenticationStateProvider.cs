using System.Security.Claims;
using Blazored.LocalStorage;
using Client.Auth.Abstract;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Auth
{
    /// <summary>
    /// Провайдер аутентификации
    /// </summary>
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        private readonly IConfiguration _configuration;

        private readonly IClaimsPrincipalConverterService _tokenProviderService;

        public IdentityAuthenticationStateProvider(
            ILocalStorageService localStorageService,
            IConfiguration configuration,
            IClaimsPrincipalConverterService tokenProviderService)
        {
            _localStorageService = localStorageService;
            _configuration = configuration;
            _tokenProviderService = tokenProviderService;
        }

        /// <summary>
        /// Получить информацию о текущем пользователе
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenNameClaimName = _configuration["AuthSetting:CookiesTokenVariable"] ?? throw new Exception("Отсутсвует наименование токена в конфигурации");
            var token = await _localStorageService.GetItemAsStringAsync(tokenNameClaimName);

            if (!string.IsNullOrEmpty(token))
            {
                var authUser = _tokenProviderService.GetClaimsPrincipal(token);
                if (authUser != null)
                    return new AuthenticationState(authUser);
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        /// <summary>
        /// Сделать пользователя аутентифицированным
        /// </summary>
        public async Task AuthorizeUser(string token)
        {
            var authUser = _tokenProviderService.GetClaimsPrincipal(token);
            if (authUser == null) return;
            var tokenNameClaimName = _configuration["AuthSetting:CookiesTokenVariable"] ?? throw new Exception("Отсутсвует наименование токена в конфигурации");
            await _localStorageService.SetItemAsStringAsync(tokenNameClaimName, token);

            var authState = Task.FromResult(new AuthenticationState(authUser));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
