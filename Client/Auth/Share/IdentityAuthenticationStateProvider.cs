using System.Security.Claims;
using Blazored.LocalStorage;
using Client.Auth.Abstract;
using Client.Configuration.ApiConfiguration;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Auth.Share
{
    /// <summary>
    /// Провайдер аутентификации
    /// </summary>
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        private readonly IClaimsPrincipalConverterService _tokenProviderService;

        public IdentityAuthenticationStateProvider(ILocalStorageService localStorageService, 
            IClaimsPrincipalConverterService tokenProviderService)
        {
            _localStorageService = localStorageService;
            _tokenProviderService = tokenProviderService;
        }

        /// <summary>
        /// Получить информацию о текущем пользователе
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenClaimName = AuthApiConfiguration.TokenVariableName;
            var token = await _localStorageService.GetItemAsStringAsync(tokenClaimName);

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
            var tokenClaimName = AuthApiConfiguration.TokenVariableName;
            await _localStorageService.SetItemAsStringAsync(tokenClaimName, token);

            var authState = Task.FromResult(new AuthenticationState(authUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task UnAuthorizeUser()
        {
            var tokenClaimName = AuthApiConfiguration.TokenVariableName;
            await _localStorageService.RemoveItemAsync(tokenClaimName);

            var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
