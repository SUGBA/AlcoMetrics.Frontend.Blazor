using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Client.Auth.Abstract;
using IdentityModel;

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
            //Получили значения UserClaims
            var userId = _tokenProviderService.GetValue(token, JwtClaimTypes.Id);
            var userName = _tokenProviderService.GetValue(token, JwtClaimTypes.Name);
            var userRoles = _tokenProviderService.GetValues(token, JwtClaimTypes.Role) ?? new List<string>();

            if (string.IsNullOrEmpty(userName) || userRoles.Count == 0 || string.IsNullOrEmpty(userId)) return null;

            var result = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.ToList();

            result.Add(new Claim(JwtClaimTypes.Id, userId));
            result.Add(new Claim(JwtClaimTypes.Name, userName));
            userRoles.ForEach(role => result.Add(new Claim(ClaimTypes.Role, role)));

            return result;
        }
    }
}
