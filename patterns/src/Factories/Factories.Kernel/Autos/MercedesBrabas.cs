using System;

namespace Factories.Kernel.Autos
{
    public class MercedesBrabas : IAuto
    {
        public void TurnOff()
        {
            Console.WriteLine("Brabas 2024 ngin turned off successfully. ");
        }

        public void TurnOn()
        {
            Console.WriteLine("Starting Brabas 2024.");
            Console.WriteLine("Brabas 2024 ngin turned on successfully. ");
        }
    }

}
