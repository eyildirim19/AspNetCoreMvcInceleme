namespace AspNetCoreMvcMiddleware.Helpers
{
    public class UserCheckMiddleware
    {
        RequestDelegate next;
        public UserCheckMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        // metot adı Invoke veya Invokeasnyc olmalıdır..
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //  işlemleri yapıyoruz.........
            await next(httpContext);
        }
    }
}