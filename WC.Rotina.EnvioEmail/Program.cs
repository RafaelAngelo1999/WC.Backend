using AutoMapper;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using WC.AppService;
using WC.AppService.Interfaces;
using WC.Domain.DTO.Email;
using WC.Domain.Interfaces;
using WC.Domain.Services;
using WC.Infra.Data.Interfaces;
using WC.Infra.Data.Repositories;

namespace WC.Rotina.EnvioEmail
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
                    IConfiguration configuration = hostContext.Configuration;

                    var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
                    optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                    services.AddScoped(d => new AppDbContext(optionBuilder.Options));

                    #region InjecaoClass
                    services.AddScoped<IEnviarEmailRotinaWebScrapingAppService, EnviarEmailRotinaWebScrapingAppService>();
                    services.AddScoped<IRotaRamificadaService, RotaRamificadaService>();
                    services.AddScoped<IRotaRamificadaRepository, RotaRamificadaRepository>();
                    services.AddScoped<IEnvioEmailService, EnvioEmailService>();
                    
                    services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
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

                    services.AddHostedService<EnvioEmailServico>();
                });
    }
}