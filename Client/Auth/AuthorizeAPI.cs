using Blazored.LocalStorage;
using Client.Auth.Abstract;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Auth
{
    /// <summary>
    /// Класс для отправки аутентификационных сообщений
    /// </summary>
    public class AuthorizeAPI : IAuthorizeAPI
    {
        private readonly IdentityAuthenticationStateProvider _authProvider;

        private readonly ILocalStorageService _localStorageService;

        public AuthorizeAPI(AuthenticationStateProvider authProvider, ILocalStorageService localStorageService)
        {
            _authProvider = (IdentityAuthenticationStateProvider)authProvider;
            _localStorageService = localStorageService;
        }

        public async Task<bool> Login(string login, string password)
        {
            ///Запрос на аутентификациб и получение токена
            
            string token = "1231jeuh1bev1jhebj1hve";
            await _localStorageService.SetItemAsync("token", token);
            _authProvider.AuthorizeUser(token);
            return true;
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
