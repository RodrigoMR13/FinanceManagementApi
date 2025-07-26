using Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Configuration
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddFinanceDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("FinanceDatabase");
            if (string.IsNullOrEmpty(connString))
                throw new InvalidOperationException("A string de conexão 'FinanceDatabase' não foi encontrada.");

            services.AddDbContext<FinanceDbContext>(options =>
                options.UseNpgsql(
                    connString,
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly("Infrastructure")
                )
            );

            return services;
        }
    }
}
