using Microsoft.IdentityModel.Tokens;
using Project.Core.Authenticate;
using Project.Core.Models;
using Project.Core.Settings;
using System.Security.Claims;
using System.Text;

namespace Project.Core.Builders.AccessToken
{
    public class AccessTokenBuilder : IAccessTokenBuilder
    {
        private string _issuer = string.Empty;
        private string _audience = string.Empty;
        private DateTime _expiresTime;
        private Claim[] _claims = Array.Empty<Claim>();
        private SigningCredentials _signingCredentials = default!;
        public IAccessToken Build()
        {
            return new AuthenticateSettings(_issuer, _audience, _claims, _expiresTime, _signingCredentials);
        }

        public IAccessTokenBuilder SetExpires(DateTime expiresTime)
        {
            _expiresTime = expiresTime;
            return this;
        }

        public IAccessTokenBuilder WithAudience(string audience)
        {
            _audience = audience;
            return this;
        }

        public IAccessTokenBuilder WithClaims(UserCredential user)
        {
            _claims = new Claim[]
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email ?? string.Empty),
                new(ClaimTypes.StreetAddress, user.Address ?? string.Empty),
                new(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty),
                new(ClaimTypes.Name, user.Name ?? string.Empty)
            };
            return this;
        }

        public IAccessTokenBuilder WithIssuer(string issuer)
        {
            _issuer = issuer;
            return this;
        }

        public IAccessTokenBuilder WithSigningCredentials(string secret, string securityAlgorithms)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            _signingCredentials = new SigningCredentials(securityKey, securityAlgorithms);
            return this;
        }
    }
}
