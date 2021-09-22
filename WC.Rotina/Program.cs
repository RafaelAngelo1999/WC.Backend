using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;
using WC.AppService.Interfaces;
using WC.AppService;
using WC.Domain.Services;
using WC.Infra.Data.Interfaces;
using WC.Domain.Interfaces;
using WC.Infra.Data.Repositories;
using WC.Shared.Configuracoes;

namespace WC.Rotina
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var debug = !(Debugger.IsAttached || args.Contains("--console") || args.Contains("-c"));

            var builder = CreateHostBuilder(args);

            if (debug)
            {
                await builder.RunAsServiceAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            new HostBuilder()
                .UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .UseConsoleLifetime()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((context, app) =>
                {
                    app.SetBasePath(Path.Combine(AppContext.BaseDirectory));
                    app.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    app.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                    app.AddEnvironmentVariables();
                    app.AddCommandLine(args);
                })
                .ConfigureContainer<ContainerBuilder>((context, container) => {

                    //Auto Mapper Configurations
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddMaps(new Assembly[]
                        {
                            Assembly.Load("HP.Crm.Domain")
                        });
                    });
                    container.RegisterInstance(mappingConfig.CreateMapper());

                })
                .ConfigureServices((context, services) =>
                {
                    services.AddLogging();
                    //services.ConfigureAppConfiguration<Aplicacao>(context.Configuration.ObterConfiguracao());
                    services.AddHostedService<WebScrapingServico>();

                    #region InjecaoClass
                    services.AddScoped<IExecutarWebScrapingAppService, ExecutarWebScrapingAppService>();
                    services.AddScoped<IRotaRamificadaService, RotaRamificadaService>();
                    services.AddScoped<IRotaRamificadaRepository, RotaRamificadaRepository>();
                    #endregion
                });
    }
}
