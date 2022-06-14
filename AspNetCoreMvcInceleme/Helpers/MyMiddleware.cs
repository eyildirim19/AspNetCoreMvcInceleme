namespace AspNetCoreMvcInceleme.Helpers
{
    // Bu middeware request detaylarına erişmek için yazıldı...
    public class MyMiddleware
    {
        // next nesnesi bir sonraki middleware tetiklemeizi sağlar...
        private readonly RequestDelegate next;

        public MyMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        // Middleware içerisinde Invoke veya InvokeAsync metodu bulunmalı. BU metot bir önceki middleware tarfından tetiklenir..Metot parametre olarak HttpContext tipinde parametre almalıdır..
        // contenxt nesnesi reqeusti yakalamamızı sağlar...
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path; // request yapılan path.

            await next(context); // sonraki middleware tetiklenir...

            string httpMetotType = context.Request.Method; // Hangi HttpMetot 
        }
    }
}
