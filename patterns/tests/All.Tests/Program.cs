using Decorator;
using Factories.Kernel.Autos;
using FactoryA;
using FactoryMethod;
using System;
using System.Reflection;

namespace All.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Decorator();
                // Simplefactory();
                FactoryMethod();
                Console.ReadKey();
            }
            catch (Exception ex)
            {

            }
        }
        static void Decorator()
        {
            DecoratorTestClass dt = new();
            dt.RunTest();
        }

        static void Simplefactory()
        {
            SolutionWithSimpleFactory solution = new ();
            solution.Run(nameof(MercedesBrabas));
        }

        static void FactoryMethod()
        {
            var type = typeof(MercedesBrabasFactory);
            var sm = LoadFactory(type.FullName);
            if (sm is null) return;
            var am = sm?.CreateAutoMobile();
            am.TurnOn();
            am.TurnOff();


        }
        static IAutoFactory LoadFactory(string name) => Assembly.GetCallingAssembly().CreateInstance(name) as IAutoFactory;
    }
}
