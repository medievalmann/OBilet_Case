using Microsoft.AspNetCore.Localization;
using OBilet_Case.Core.Interfaces.IManager;
using System.Globalization;
using UAParser;

namespace OBilet_Case.UI.Middlewares
{
    public class UserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUserContextManager userContextManager)
        {
            userContextManager.SessionID = httpContext.Session.Id;

            var cultureFeature = httpContext.Features.Get<IRequestCultureFeature>();
            var currentCulture = cultureFeature?.RequestCulture.UICulture;
            userContextManager.Culture = currentCulture ?? CultureInfo.CurrentUICulture;

            var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgent);

            userContextManager.BrowserName = clientInfo.UA.Family;
            userContextManager.BrowserVersion = clientInfo.UA.Major + "." + clientInfo.UA.Minor;

            await _next(httpContext);
        }
    }
}
