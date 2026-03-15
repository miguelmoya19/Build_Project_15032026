using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Software.Application.Interfaces;
using Software.Application.Interfaces.Usuario;
using Software.Application.Mapping;
using Software.Application.Services;
using Software.Domain.Common;
using Software.Domain.Interfaces.Repository;
using Software.Infraestructure.Middleware;
using Software.Infraestructure.Persistence;
using Software.Infraestructure.Repository;
using Software.Infraestructure.Security;
using Software.Shared.Settings;
using System.Text;

namespace Software.NSerio.ApplicationServices
{
    public static class ServicesRegistration
    {

        public static IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {


            Console.WriteLine(configuration.GetConnectionString("LocalConnection"));

            service.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("LocalConnection")
                );

                options.AddInterceptors(
                    sp.GetRequiredService<AuditInterceptor>()
                );
            });

            service.AddCors(options =>
            {
                options.AddPolicy("DevPolicy",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            service.AddHttpContextAccessor();
            service.AddScoped<ICurrentUserContext, CurrentUserContext>();
            service.AddScoped<AuditInterceptor>();
            service.AddScoped<IJwtGenerator, JwtGenerator>();

            service.AddScoped<IRepositoryProjects, ProjectRepository>();
            service.AddScoped<IRepositoryDashboard, DashboardRepository>();
            service.AddScoped<IRepositoryTask, TaskRepository>();
            service.AddScoped<IRepositoryDeveloper, DeveloperRepository>();
 
            service.AddScoped<IProject, ProjectService>();
            service.AddScoped<IDashDeveloper, DashboardDeveloperService>();
            service.AddScoped<ITask, TaskServices>();
            service.AddScoped<IDev, DeveloperService>();


            service.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            service.AddScoped<IHashByCrypt, BCryptPasswordHasher>();

            service.AddAutoMapper(typeof(ProjectProfile).Assembly);
            service.AddAutoMapper(typeof(DashboardProfile).Assembly);
            service.AddAutoMapper(typeof(TasksProfile).Assembly);
            service.AddAutoMapper(typeof(DevelopersProfile).Assembly);

            return service;

        }


        public static IServiceCollection AddJwtBearerApplication(this IServiceCollection service, IConfiguration configuration)
        {

            service
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty))
                };
            });

            return service;

        }

    }
}
