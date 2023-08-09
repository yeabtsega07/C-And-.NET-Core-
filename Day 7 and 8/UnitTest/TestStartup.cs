using System;
using System.Reflection;
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.Abstractions;

namespace BlogApp.Tests
{
    public class TestStartup : IDisposable
    {
        private readonly ServiceProvider _provider;

        public TestStartup(Assembly assembly)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });

            // Add other dependencies here

            services.AddSingleton<ITestOutputHelper>(new TestOutputHelper());

            _provider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider => _provider;

        public void Dispose()
        {
            if (_provider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        public IHost BuildHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton(ServiceProvider);
                })
                .Build();
        }
    }
}

