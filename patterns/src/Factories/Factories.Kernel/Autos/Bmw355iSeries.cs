using System;

namespace Factories.Kernel.Autos
{
    public class Bmw355iSeries : IAuto
    {
        public void TurnOff()
        {
            Console.WriteLine("Bmw 355i series ngin turned off successfully. ");
        }

        public void TurnOn()
        {
            Console.WriteLine("Starting Bmw 355i series. ");
            Console.WriteLine("Bmw 355i series ngin turned on successfully. ");
        }
    }

}
