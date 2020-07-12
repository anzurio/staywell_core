// <copyright file="Startup.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api
{
    using Cards.Api.Data;
    using Cards.Api.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Net;

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
            services.AddDbContext<CardsContext>(options =>
                options.UseInMemoryDatabase("Cards"));

            services.AddControllers();
            services.AddTransient<DeckService>();
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // NOTE: Quick-dirty way to add exception handling without changing the test's initial API paradigm.
                app.UseExceptionHandler(new ExceptionHandlerOptions()
                {
                    ExceptionHandler = async (context) =>
                    {
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null && contextFeature.Error != null)
                        {
                            // Ideally the response Content and ContentType should be determined by the Request's Accept Header 
                            // which is taken care by using IActionResult in the endpoints. See note above.
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            context.Response.ContentType = "text/plain";
                            await context.Response.WriteAsync(contextFeature.Error.Message);
                        }
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
