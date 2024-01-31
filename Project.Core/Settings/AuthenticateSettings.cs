using Microsoft.IdentityModel.Tokens;
using Project.Core.Authenticate;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Project.Core.Settings
{
    public class AuthenticateSettings : IAccessToken
    {
        public AuthenticateSettings(string issuer, string audience, Claim[] claims, DateTime expires, SigningCredentials signingCredentials)
        {
            Issuer = issuer;
            Audience = audience;
            Claims = claims;
            Expires = expires;
            SigningCredentials = signingCredentials;
        }

        private string Issuer { get; }
        private string Audience { get; }
        private Claim[] Claims { get; }
        private DateTime Expires { get; }
        private SigningCredentials SigningCredentials { get; }

        public string Write()
        {
            var token = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    claims: Claims,
                    expires: Expires,
                    signingCredentials: SigningCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
