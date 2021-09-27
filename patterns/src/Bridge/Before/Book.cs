using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Before
{
    interface IManuscript
    {
        void Print();
    }
    public class Book : IManuscript
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public  void Print()
        {
            Console.WriteLine("Title: "+ Title);
            Console.WriteLine("Author: "+ Author);
            Console.WriteLine("Text: "+ Text);
            Console.WriteLine();
        }
    }

}
