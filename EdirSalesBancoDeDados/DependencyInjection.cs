using EdirSalesBancoDeDados.Application.Interfaces;
using EdirSalesBancoDeDados.Application.UseCases;
using EdirSalesBancoDeDados.Domain.Interfaces;
using EdirSalesBancoDeDados.Infrastructure;
using EdirSalesBancoDeDados.Infrastructure.Repositories;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Application.AutoMapper;
using System.Reflection;

namespace EdirSalesBancoDeDados
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddUseCase(services);
            AddRepository(services);
            AddFluentMigrator(services, configuration);
            AddAutoMapper(services);
            return services;
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            //criei uma extension de configuration pra acessar a string de conexao por metodo
            var connectionString = configuration.GetConnectionString("ConnectionSQL");
            services.AddDbContext<EdirSalesContext>(dbContextOptions =>
            {
                //passo a minha connectionstring pro metodo do sql
                dbContextOptions.UseSqlServer(connectionString);
            });
        }
        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionSQL");

            //função do fluent
            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("EdirSalesBancoDeDados")).For.All();
            });
        }
        private static IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IMunicipeRepository, MunicipeRepository>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();

            return services;
        }
        private static IServiceCollection AddUseCase(IServiceCollection services)
        {
            services.AddScoped<IGrupoUseCase, GrupoUseCase>();
            services.AddScoped<IMunicipeUseCase, MunicipeUseCase>();
            services.AddScoped<ISolicitacaoUseCase, SolicitacaoUseCase>();

            return services;
        }
    }
}
