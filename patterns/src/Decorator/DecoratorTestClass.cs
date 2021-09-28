using Decorator.Objects.Components;
using Decorator.Objects.ConcreteComponents;
using Decorator.Objects.ConcreteDecorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class DecoratorTestClass
    {
        public void RunTest()
        {
            Pizza largerPizza = new LargePizza();
            Console.WriteLine("Large Pizza without cheese:");
            Print(largerPizza);
            // decorate with cheese
            largerPizza = new Cheese(largerPizza);
            Console.WriteLine("Large Pizza with cheese:");
            Print(largerPizza);

            // medium pizza with cheese, Ham and Pepper
            Console.WriteLine("\n\n");
            Pizza medium = new MediumPizza();
            Console.WriteLine("medium Pizza without any:");
            Print(medium);
            medium = new Cheese(medium);
            Console.WriteLine("medium Pizza With cheese:");
            Print(medium);
            medium = new Ham(medium);
            Console.WriteLine("medium Pizza With ham:");
            Print(medium);
            medium = new Peppers(medium);
            Console.WriteLine("medium Pizza With peppers:");
            Print(medium);

        }
        private static void Print(Pizza pizza)
        {
            Console.WriteLine(pizza.GetDescription());
            Console.WriteLine("{0:C2}", pizza.CalculateCost());
        }
    }
}
