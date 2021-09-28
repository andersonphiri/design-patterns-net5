using Decorator;
using System;

namespace All.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Decorator();
                Console.ReadKey();
            }
            catch (Exception ex)
            {

            }
        }
        static void Decorator()
        {
            DecoratorTestClass dt = new();
            dt.RunTest();
        }
    }
}
