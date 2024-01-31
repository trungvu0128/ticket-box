using Microsoft.IdentityModel.Tokens;
using Project.Core.Authenticate;
using Project.Core.Models;

namespace Project.Core.Builders.AccessToken
{
    public interface IAccessTokenBuilder
    {
        IAccessTokenBuilder WithIssuer(string issuer);
        IAccessTokenBuilder WithAudience(string audience);
        IAccessTokenBuilder WithClaims(UserCredential user);
        IAccessTokenBuilder SetExpires(DateTime expiresTime);
        IAccessTokenBuilder WithSigningCredentials(string secret, string securityAlgorithms);
        IAccessToken Build();
    }
}
