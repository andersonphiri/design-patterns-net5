using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Autos
{
    public interface IAutoMobile
    {
        string Package { get; }
    }

    public class Minicooper : IAutoMobile {

        public string Package { get; private set; }
        public Minicooper()
        {
            Package = "Economy";
        }
        public void AddSportPackage() => Package = "Sport Package";

        public void AddLuxuryPackage() => Package = "Luxury Package";

    }

}
