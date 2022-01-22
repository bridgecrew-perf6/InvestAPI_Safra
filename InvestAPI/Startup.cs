using Invest.Repositories;
using Invest.Repositories.Context;
using Invest.Repositories.Contracts;
using Invest.Services.Business;
using Invest.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace InvestAPI
{
    public class Startup
    {
        private static string Host = "ec2-18-211-41-246.compute-1.amazonaws.com";
        private static string User = "hhcjncmqsdgdpy";
        private static string DBname = "daqu3skamvcq6t";
        private static string Password = "9d2711737db14d0a19382076a094e663be9c96a0cf4a07ce39d67aa33beeddbd";
        private static string Port = "5432";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connString =
                string.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSL Mode=Require;Trust Server Certificate=true",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connString));
            services.AddControllers();
            services.AddScoped<IAcaoServices, AcaoServices>();
            services.AddScoped<IAcaoRepository, AcaoRepository>();
            services.AddScoped<IYahooService, YahooService>();
            services.AddScoped<IOperacaoServices, OperacaoServices>();
            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Invest.Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proeventos.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
