using AbstractFactory.Autos;
using System;

namespace AbstractFactory
{
    public interface IAutoFactory
    {
        IAutoMobile CreateSportsCar();
        IAutoMobile CreateLuxuryCar();
        IAutoMobile CreateEconomyCar();

    }

    public class MinicooperFactory : IAutoFactory
    {
        public IAutoMobile CreateEconomyCar()
        {
            return new Minicooper(); ;
        }

        public IAutoMobile CreateLuxuryCar()
        {
            var m = new Minicooper();
            m.AddLuxuryPackage();
            return m;
        }

        public IAutoMobile CreateSportsCar()
        {
            var m = new Minicooper();
            m.AddSportPackage();
            return m;
        }
    }

}
