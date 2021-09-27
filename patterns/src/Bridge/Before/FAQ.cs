using System;
using System.Collections.Generic;

namespace Bridge.Before
{
    public class FAQ : IManuscript
    {
        public string Title { get; set; }
        public Dictionary<string, string> Questions { get; set; }

        public FAQ() 
        {
            Questions = new Dictionary<string, string>();
        }

        public  void Print()
        {
            Console.WriteLine("Title: "+ Title);
            foreach (var question in Questions)
            {
                Console.WriteLine("   Question"+ question.Key);
                Console.WriteLine("   Answer"+ question.Value);
            }
            Console.WriteLine();
        }
    }

}
