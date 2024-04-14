using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Client.Auth.Abstract;
using Client.Extensions;

namespace Client.Auth.PasswordAuthentification
{
    public class PasswordClaimsPrincipalConverterService : IClaimsPrincipalConverterService
    {
        private readonly IConfiguration _configuration;

        private readonly ITokenProviderService _tokenProviderService;

        public PasswordClaimsPrincipalConverterService(IConfiguration configuration, ITokenProviderService tokenProviderService)
        {
            _tokenProviderService = tokenProviderService;
            _configuration = configuration;
        }

        public ClaimsPrincipal? GetClaimsPrincipal(string token)
        {
            return new ClaimsPrincipal(GetIdentityFromJwtToken(token));
        }

        /// <summary>
        /// Сформировать из списка UserClaims UserIdentity
        /// </summary>
        /// <param name="token"> Токен </param>
        /// <returns></returns>
        private ClaimsIdentity GetIdentityFromJwtToken(string token)
        {
            return new(ParseClaimsFromJwt(token), "jwt");
        }

        /// <summary>
        /// Получить добавленные UserClaims
        /// Добавлял имя пользователя и список его ролей
        /// </summary>
        /// <param name="token"> Токен </param>
        /// <returns></returns>
        private List<Claim>? ParseClaimsFromJwt(string token)
        {
            var userNameClaimName = _configuration.TryGetValue("AuthSetting:UserNameClaim", "Отсутсвует наименование ключа для имени пользователя в конфигурации");
            var userRolesClaimName = _configuration.TryGetValue("AuthSetting:UserRolesClaim", "Отсутсвует наименование ключа для роли пользователя в конфигурации");

            //Получили значения UserClaims
            var userName = _tokenProviderService.GetValue(token, userNameClaimName);
            var userRoles = _tokenProviderService.GetValues(token, userRolesClaimName) ?? new List<string>();

            if (string.IsNullOrEmpty(userName)) return null;

            var result = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.ToList();
            result.Add(new Claim(userNameClaimName, userName));
            userRoles.ForEach(role => result.Add(new Claim(userRolesClaimName, role)));

            return result;
        }
    }
}
