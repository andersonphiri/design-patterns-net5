using Decorator.Objects.Components;
using Decorator.Objects.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Objects.ConcreteDecorators
{
    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza) : base(pizza)
        {
            Description = "Cheese";
        }
        public override string GetDescription()
        {
            return string.Format("{0},  {1}", _pizza.GetDescription(), Description);
        }
        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 1.23;
        }
    }
    public class Ham : PizzaDecorator
    {
        public Ham(Pizza pizza) : base(pizza)
        {
            Description = "Ham";
        }
        public override string GetDescription()
        {
            return string.Format("{0},  {1}", _pizza.GetDescription(), Description);
        }
        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 1.23;
        }
    }
    public class Peppers : PizzaDecorator
    {
        public Peppers(Pizza pizza) : base(pizza)
        {
            Description = "Peppers";
        }
        public override string GetDescription()
        {
            return string.Format("{0},  {1}", _pizza.GetDescription(), Description);
        }
        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 1.23;
        }
    }
}
