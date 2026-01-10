namespace Application.Services
{
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class GenericHttpContext : IGenericHttpContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GenericHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? ValidarHttpContext(string key)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string? result = null;

            if (httpContext != null && httpContext.Items.ContainsKey(key))
            {
                result = httpContext.Items[key]?.ToString();
            }

            if (httpContext == null || httpContext.User == null)
                return null;

            var claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == key);
                result = claim?.Value;

            return result;
        }
    }
}
