using System.Security.Claims;

namespace Client.Auth.Abstract
{
    /// <summary>
    /// Сервис для генерации пользователя на основе jwt токена
    /// </summary>
    public interface IClaimsPrincipalConverterService
    {
        /// <summary>
        /// Собрать ClaimsPrincipal из токена
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsPrincipal? GetClaimsPrincipal(string token);
    }
}
