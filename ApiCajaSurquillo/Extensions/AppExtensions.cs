using ApiPrueba.Midleware;
using Microsoft.AspNetCore.Builder;

namespace ApiPrueba.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
