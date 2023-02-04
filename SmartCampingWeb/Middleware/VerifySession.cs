namespace SmartCampingWeb.Middleware
{
    public class VerifySession
    {
        private readonly RequestDelegate _requestDelegate;

        public VerifySession(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var user = httpContext.Session.GetString("userId");
            var token = httpContext.Session.GetString("token");
            var tokenExpiration = httpContext.Session.GetString("tokenExpiration");

            if (user == null && (httpContext.Request.Path.ToString() != "/Login/Index" 
                && httpContext.Request.Path.ToString() != "/Login/Register"
                && httpContext.Request.Path.ToString() != "/"))
            {
                httpContext.Response.Redirect("/Login/Index");
            }
            else if(user != null && (httpContext.Request.Path.ToString() == "/Login/Index"
                || httpContext.Request.Path.ToString() == "/Login/Register"
                || httpContext.Request.Path.ToString() == "/"))
            {
                if(DateTime.Now > DateTime.Parse(tokenExpiration))
                {
                    httpContext.Session.Clear();
                    httpContext.Response.Redirect("/Login/Index");
                }
                else
                {
                    httpContext.Response.Redirect("/Alojamentos/Index");
                }
            }
            return _requestDelegate(httpContext);
        }
    }

    public static class VerifySessionExtensions
    {
        public static IApplicationBuilder UseVerifySession(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VerifySession>();
        }
    }
}
