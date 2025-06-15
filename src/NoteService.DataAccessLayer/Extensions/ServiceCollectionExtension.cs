using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteService.DataAccessLayer.Interfaces;

namespace NoteService.DataAccessLayer.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
                configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<NoteAppDbContext>(opts => 
                opts.UseSqlServer(connectionString));

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
