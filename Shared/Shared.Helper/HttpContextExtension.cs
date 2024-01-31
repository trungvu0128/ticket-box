using Microsoft.AspNetCore.Http;

namespace Shared.Helper
{
    public static class HttpContextExtension
    {
        public static string? GetValueFromCookie(this HttpContext httpContext, string key)
        {
            return httpContext.Request.Cookies[key];
        }

        public static void SetValueToCookie(this HttpContext httpContext, string key, string value, DateTime expiredTime)
        {
            httpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                SameSite = SameSiteMode.None,
                HttpOnly = true,
                Expires = expiredTime,
                Secure = true
            });
        }
    }
}
