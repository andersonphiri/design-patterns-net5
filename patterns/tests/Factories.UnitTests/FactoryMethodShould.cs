using FactoryMethod;
using System;
using System.Reflection;
using Xunit;
using FluentAssertions;
using Factories.Kernel.Autos;

namespace Factories.UnitTests
{
    public class FactoryMethodShould

    {
        [Fact]
        public void ReturnInstanceOfSelectedTypeName()
        {
            var type = typeof(MercedesBrabasFactory);
            IAutoFactory af = LoadFactory(type);
            af.GetType().Should().Be(type);
            var car = af.CreateAutoMobile();
            car.GetType().Should().Be(typeof(MercedesBrabas));

        }

        
        static IAutoFactory LoadFactory(Type type) => Activator.CreateInstance(type) as IAutoFactory;
    }
}
