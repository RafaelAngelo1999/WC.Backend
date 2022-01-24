using AutoMapper;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using WC.AppService;
using WC.AppService.Interfaces;
using WC.Domain.Interfaces;
using WC.Domain.Interfaces.WebCrawler;
using WC.Domain.Interfaces.WebScraping;
using WC.Domain.Services;
using WC.Infra.Data.Interfaces;
using WC.Infra.Data.Repositories;

namespace WC.BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            #region InjecaoClass
            services.AddScoped<IInserirProdutoAppService, InserirProdutoAppService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IInserirRotaSementeAppService, InserirRotaSementeAppService>();
            services.AddScoped<IRotaSementeService, RotaSementeService>();
            services.AddScoped<IRotaSementeRepository, RotaSementeRepository>();

            services.AddScoped<IExecutarWebCrawlerAppService, ExecutarWebCrawlerAppService>();
            services.AddScoped<IWebCrawlerService, WebCrawlerService>();

            services.AddScoped<IExecutarWebScrapingAppService, ExecutarWebScrapingAppService>();
            services.AddScoped<IWebScrapingService, WebScrapingService>();

            services.AddScoped<IRotaRamificadaService, RotaRamificadaService>();
            services.AddScoped<IRotaRamificadaRepository, RotaRamificadaRepository>();

            services.AddScoped<IWebScrapingHavanService, WebScrapingHavanService>();
            services.AddScoped<IWebCrawlerHavanService, WebCrawlerHavanService>();

            services.AddScoped<IWebScrapingDrogaRaiaService, WebScrapingDrogaRaiaService>();

            services.AddScoped<IHttpClientService, HttpClientService>();

            #endregion

            services.AddControllers();


            //Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(new Assembly[]
                {
                    Assembly.Load("WC.Domain"),
                    Assembly.Load("WC.WebApi")
                });

            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHttpContextAccessor();

            //var key = Encoding.ASCII.GetBytes("c8c51b23df4531bdbba94711cedbab2d4501f902");
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WC.BackEnd", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WC.BackEnd v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
