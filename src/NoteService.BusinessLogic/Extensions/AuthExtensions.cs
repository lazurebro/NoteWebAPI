using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NoteService.BusinessLogic.Interfaces;
using NoteService.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.BusinessLogic.Extensions
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<JwtService>();
            services.Configure<AuthSettings>(
                configuration.GetSection("AuthSettings"));
            services.AddTransient<IAuthService, AuthService>();

            var authSettings = configuration.GetSection(nameof(AuthSettings))
                .Get<AuthSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authSettings!.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authSettings!.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(authSettings!.GetSecretKey()))
                    };
                });

            return services;
        }
    }
}
