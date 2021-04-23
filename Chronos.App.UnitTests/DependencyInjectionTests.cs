using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Chronos.App.UnitTests
{
    public class DependencyInjectionTests
    {
        private readonly IServiceCollection _services;

        public DependencyInjectionTests()
        {
            _services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .Build();
            var startup = new Startup(configuration);

            startup.ConfigureServices(_services);
        }

        private void InstanceShouldBeCreated(Type type)
        {
            var serviceProvider = _services.BuildServiceProvider();
            var instance = serviceProvider.GetService(type);
            Assert.NotNull(instance);
        }

        [Theory()]
        [MemberData(nameof(Controllers))]
        public void ControllerShouldBeInstantiated(Type type)
        {
            _services.AddTransient(type);
            InstanceShouldBeCreated(type);
        }

        public static IEnumerable<object[]> Controllers =>
            typeof(Startup).GetTypeInfo().Assembly
                .GetTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                .Select(x => new object[] { x })
                .ToList();
    }
}
