using System;

namespace Composite
{
    public class Person : Party
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public void Stats()
        {
            Console.WriteLine("{0} has {1} gold coins.", Name, Gold);
        }
    }

    public interface Party
    {
        string Name { get; }
        public int Gold { get; set; }
        void Stats();
    }
}
