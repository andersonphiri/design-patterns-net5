using Decorator.Objects.Components;

namespace Decorator.Objects.ConcreteComponents
{
    public class MediumPizza : Pizza
    {
        public MediumPizza()
        {
            Description = "Medium Pizza";
        }
        public override double CalculateCost()
        {
            return 9.30;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }





}
