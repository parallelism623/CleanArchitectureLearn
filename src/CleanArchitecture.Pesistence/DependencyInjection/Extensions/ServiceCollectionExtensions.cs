using CleanArchitecture.Domain.Entities.Identity;
using CleanArchitecture.Pesistence.DependencyInjection.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Pesistence.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSqlConfiguration(this IServiceCollection services)
        {
            services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, builder) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>().CurrentValue;
                builder.EnableDetailedErrors(true)
                       .EnableSensitiveDataLogging(true)
                       .UseLazyLoadingProxies(true)
                       .UseSqlServer(
                            connectionString: configuration.GetConnectionString("ConnectionStrings"),
                            sqlServerOptionsAction: optionBuilder =>
                                optionBuilder.ExecutionStrategy(
                                    dependencies => new SqlServerRetryingExecutionStrategy(
                                        dependencies: dependencies,
                                        maxRetryCount: options.MaxRetryCount,
                                        maxRetryDelay: options.MaxRetryDelay,
                                        errorNumbersToAdd: options.ErrorNumbersToAdd
                                        ))
                                    .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));

            });

            services.AddIdentityCore<AppUser>()
                    .AddRoles<AppRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.AllowedForNewUsers = true; //default true
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2); // default 5
                options.Lockout.MaxFailedAccessAttempts = 3; //default 5

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

            });
        }
        public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptions(this IServiceCollection services, IConfigurationSection section)
            => services.AddOptions<SqlServerRetryOptions>()
                       .Bind(section)
                       .ValidateDataAnnotations()
                       .ValidateOnStart();
    }
}
