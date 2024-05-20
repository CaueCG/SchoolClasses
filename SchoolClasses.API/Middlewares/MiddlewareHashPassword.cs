using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SchoolClasses.Application.RequestModels;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolClasses.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareHashPassword
    {
        private readonly RequestDelegate _next;

        public MiddlewareHashPassword(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST" &&
                httpContext.Request.Path.StartsWithSegments("/api/aluno"))
            {
                using (StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    var body = await reader.ReadToEndAsync();

                    var requestBodyStream = new MemoryStream(Encoding.UTF8.GetBytes(body));

                    InputAluno aluno = JsonSerializer.Deserialize<InputAluno>(body, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    aluno.Senha = ConvertHashPassword(aluno.Senha);

                    var updatedBody = JsonSerializer.Serialize(aluno);

                    var updatedBodyBytes = Encoding.UTF8.GetBytes(updatedBody);
                    httpContext.Request.Body = new MemoryStream(updatedBodyBytes);
                    httpContext.Request.Body.Position = 0;
                }
            }
            await _next(httpContext);
        }

        private string ConvertHashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareHashPassword(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareHashPassword>();
        }
    }
}
