using Factories.Kernel.Autos;

namespace FactoryA
{
    /// <summary>
    /// the problem is, if we want to introduce new car say Subaru. first we need to implement
    /// the IAuto interface, next we edit the GetCar method to introduce a new case, then, return the new model
    /// By doing that we have broken the SOLID principle : Open for extension and closed for Modification
    /// be cause we have modified the get car method
    /// </summary>
    public class ProblemFactoryA
    {
        public void Run(string nameOfCar)
        {
            IAuto car = GetCar(nameOfCar);
            car.TurnOn();
            car.TurnOff();
        }
        static IAuto GetCar(string name)
        {
            switch (name)
            {
                case "bmw":
                    return new Bmw355iSeries();
                case "mercedes":
                    return new MercedesBrabas();
                default:
                    return new CarNotFound();
            }
        }
    }
}
