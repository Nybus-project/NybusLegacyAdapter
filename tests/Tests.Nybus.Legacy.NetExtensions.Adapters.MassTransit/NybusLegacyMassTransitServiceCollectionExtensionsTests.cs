using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Nybus;
using Nybus.MassTransit;

namespace Tests
{
    [TestFixture]
    public class NybusLegacyMassTransitServiceCollectionExtensionsTests
    {
        [Test, AutoMoqData]
        public void AddNybusLegacyWithMassTransit_registers_MassTransitOptions(IServiceCollection services, NybusLegacyConfiguration configuration)
        {
            services.AddNybusLegacyWithMassTransit(configuration);

            Mock.Get(services).Verify(p => p.Add(It.Is<ServiceDescriptor>(sd => sd.For<MassTransitOptions>())));
        }

        [Test, AutoMoqData]
        public void AddNybusLegacyWithMassTransit_registers_BusEngine(IServiceCollection services, NybusLegacyConfiguration configuration)
        {
            services.AddNybusLegacyWithMassTransit(configuration);

            Mock.Get(services).Verify(p => p.Add(It.Is<ServiceDescriptor>(sd => sd.For<IBusEngine>())));
        }

        [Test, AutoMoqData]
        public void AddNybusLegacyWithMassTransit_registers_MassTransitConnectionDescriptor(IServiceCollection services, NybusLegacyConfiguration configuration)
        {
            services.AddNybusLegacyWithMassTransit(configuration);

            Mock.Get(services).Verify(p => p.Add(It.Is<ServiceDescriptor>(sd => sd.For<MassTransitConnectionDescriptor>())));
        }
    }
}