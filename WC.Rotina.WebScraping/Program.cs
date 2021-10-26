using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WC.AppService;
using WC.AppService.Interfaces;
using WC.Domain.Interfaces;
using WC.Domain.Services;
using WC.Infra.Data.Interfaces;
using WC.Infra.Data.Repositories;

namespace WC.Rotina.WebScraping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            CreateDatabaseIfNotExist(host);

            host.Run();
        }

        private static void CreateDatabaseIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration Configuration = hostContext.Configuration;

                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    });

                    #region InjecaoClass
                    services.AddScoped<IInserirProdutoAppService, InserirProdutoAppService>();
                    services.AddScoped<IProdutoService, ProdutoService>();
                    services.AddScoped<IProdutoRepository, ProdutoRepository>();
                    services.AddScoped<IExecutarWebScrapingAppService, ExecutarWebScrapingAppService>();
                    services.AddScoped<IRotaRamificadaService, RotaRamificadaService>();
                    services.AddScoped<IRotaRamificadaRepository, RotaRamificadaRepository>();
                    services.AddScoped<IWebScrapingHavanService, WebScrapingHavanService>();
                    services.AddScoped<IWebScrapingService, WebScrapingService>();
                    services.AddScoped<IHttpClientService, HttpClientService>();
                    #endregion

                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddMaps(new Assembly[]
                        {
                    Assembly.Load("WC.Domain"),
                        });

                    });
                    var mapper = mappingConfig.CreateMapper();
                    services.AddSingleton(mapper);

                    services.AddHostedService<WebScrapingServico>();
                });
    }
}