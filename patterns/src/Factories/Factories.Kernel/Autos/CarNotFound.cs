using System;

namespace Factories.Kernel.Autos
{
    public class CarNotFound : IAuto
    {
        public void TurnOff()
        {
            Console.WriteLine("Car not found");
        }

        public void TurnOn()
        {
            Console.WriteLine("Car not found");
        }
    }

}
