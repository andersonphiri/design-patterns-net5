using Factories.Kernel.Autos;
using System;

namespace FactoryMethod
{
    public interface IAutoFactory
    {
        IAuto CreateAutoMobile();
    }

    public class BmwFactory : IAutoFactory
    {
        public IAuto CreateAutoMobile()
        {
            return new Bmw355iSeries();
        }
    }

    public class MercedesBrabasFactory : IAutoFactory
    {
        public IAuto CreateAutoMobile()
        {
            return new MercedesBrabas();
        }
    }


}
