using Decorator.Objects.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Objects.ConcreteComponents
{
    public class LargePizza : Pizza
    {
        public LargePizza()
        {
            Description = "Large Pizza";
        }
        public override double CalculateCost()
        {
            return 15.60;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }

    public class SmallPizza : Pizza
    {
        public SmallPizza()
        {
            Description = "Small Pizza";
        }
        public override double CalculateCost() => 4.39;

        public override string GetDescription() => Description;
    }




}
