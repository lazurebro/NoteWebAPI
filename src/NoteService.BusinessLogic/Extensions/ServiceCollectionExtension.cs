using Microsoft.Extensions.DependencyInjection;
using NoteService.BusinessLogic.Interfaces;

namespace NoteService.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddNoteService(this IServiceCollection services)
        {
            services.AddScoped<INoteService, Services.NoteService>();

            return services;
        }
    }
}
