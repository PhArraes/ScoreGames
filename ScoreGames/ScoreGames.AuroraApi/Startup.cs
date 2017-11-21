using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using ScoreGames.AppService.Interfaces;
using ScoreGames.AppService;
using ScoreGames.Domain.Entities.Aurora;
using ScoreGames.Domain.Services;
using ScoreGames.Domain.Interfaces.Services;
using ScoreGames.Domain.Interfaces.Factories;

namespace ScoreGames.AuroraApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc();

            services.Add(new ServiceDescriptor(typeof(IScoreAuroraFactory), typeof(ScoreAuroraFactory), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IAuroraAssistantService), typeof(AuroraAssistantService), ServiceLifetime.Transient));

            services.Add(new ServiceDescriptor(typeof(IScoreAppService), typeof(ScoreAppService), ServiceLifetime.Transient));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404
                    && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
