using Factories.Kernel.Autos;

namespace FactoryA
{
    public class SolutionWithSimpleFactory
    {
        public void Run(string carname)
        {
            SimpleAutoFactory simpleAutoFactory = new SimpleAutoFactory();
            IAuto car = simpleAutoFactory.CreateInstance(carname);
            car.TurnOn();
            car.TurnOff();
        }
    }
}
