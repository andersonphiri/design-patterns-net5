using Decorator.Objects.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Objects.Decorators
{
    public class PizzaDecorator : Pizza
    {
        protected Pizza _pizza;
        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override double CalculateCost() => _pizza.CalculateCost();
        public override string GetDescription() => _pizza.GetDescription();
    }
}
