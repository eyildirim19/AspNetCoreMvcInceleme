namespace AspNetCoreMvcMiddleware.Helpers
{
    public static class AppMiddewareExtensions
    {
        // Middlewarelar program.cs içerisinde IApplicationBuilder interfacesine extentd edilmiş metotladır. Bizde IApplicationBuilder tipinde extension metot yazarak metotlarımız program.cs içerisinde app nesnesi üzerinden Use ile çağırabiliriz...
        public static IApplicationBuilder UseMyControl(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }

        public static IApplicationBuilder UseCheckControl(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserCheckMiddleware>();
        }
    }
}
