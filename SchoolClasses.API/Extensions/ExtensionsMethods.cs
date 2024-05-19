using SchoolClasses.Application.Services;
using SchoolClasses.Core.Interfaces.Repositories;
using SchoolClasses.Infrastructure.DataBase;
using SchoolClasses.Infrastructure.Repositories;

namespace SchoolClasses.API.Extensions
{
    public static class ExtensionsMethods
    {
        public static void AddInterfacesDatabase(IServiceCollection service)
        {
            service.AddScoped<IDatabaseProvider, DatabaseProvider>();
        }
        public static void AddInterfacesRepositories(IServiceCollection service)
        {
            service.AddScoped<IAlunoRepository, AlunoRepository>();
            service.AddScoped<ICursoRepository, CursoRepository>();
            service.AddScoped<ITurmaRepository, TurmaRepository>();
        }
        public static void AddInterfacesServices(IServiceCollection service)
        {
            service.AddScoped<IAlunoService, AlunoService>();
            service.AddScoped<ICursoService, CursoService>();
            service.AddScoped<ITurmaService, TurmaService>();
        }
    }
}
