using Microsoft.AspNetCore.Http;
using Project.Core.Models;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Project.Core.Extensions
{
    public static class AuthenticateExtension
    {
        /// <summary>
        /// Write refresh token
        /// </summary>
        /// <returns></returns>
        public static string WriteRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        /// <summary>
        /// Get user credential
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static UserCredential? GetUserCredential(this HttpContext context)
        {
            var userContext = context.User;
            if (context.User?.Identity?.IsAuthenticated ?? false)
            {
                return new UserCredential
                {
                    Name = userContext.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty,
                    Id = int.Parse(userContext.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0"),
                    Email = userContext.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty,
                    Address = userContext.FindFirst(ClaimTypes.StreetAddress)?.Value ?? string.Empty,
                    PhoneNumber = userContext.FindFirst(ClaimTypes.MobilePhone)?.Value ?? string.Empty,
                };
            }
            return null;
        }
    }
}
