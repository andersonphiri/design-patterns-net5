using System;

namespace Bridge.Before
{
    public class TermPaper : IManuscript
    {
        public string Class { get; set; }
        public string Student { get; set; }
        public string Text { get; set; }
        public string References { get; set; }

        public  void Print()
        {
            Console.WriteLine("Class: " + Class);
            Console.WriteLine("Student: "+ Student);
            Console.WriteLine("Text: "+ Text);
            Console.WriteLine("References: "+ References);
            Console.WriteLine();
        }
    }

}
