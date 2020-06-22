// <copyright file="Program.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Cards.Api.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var cardsContext = scope.ServiceProvider.GetService<CardsContext>();

                DataGenerator.Initialize(cardsContext);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
