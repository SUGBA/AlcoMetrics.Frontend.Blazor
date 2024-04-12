using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Auth
{
    /// <summary>
    /// Провайдер аутентификации
    /// </summary>
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public IdentityAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// Получить информацию о текущем пользователе
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ///Здесь должен быть запрос на получение токена

            var token = await _localStorageService.GetItemAsStringAsync("token");

            if (!string.IsNullOrEmpty(token))
            {
                var authUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>() { new Claim(type: ClaimTypes.Name, value: "user1") }, "jwt"));
                return new AuthenticationState(authUser);
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        /// <summary>
        /// Сделать пользователя аутентифицированным
        /// </summary>
        public void AuthorizeUser(string token)
        {
            ///Нужно распрасить token

            var authUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()
            {
                new Claim(type: ClaimTypes.Name, value: "user1")
            }, "jwt"));

            var authState = Task.FromResult(new AuthenticationState(authUser));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
