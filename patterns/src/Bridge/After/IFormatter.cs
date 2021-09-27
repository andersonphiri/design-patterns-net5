using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.After
{
    public interface IFormatter
    {
        string Format(string key, string value);
    }

    public interface IManuscript
    {
        void Print();
    }

    public abstract class ManuscriptBase : IManuscript
    {
        protected readonly IFormatter _formatter;

        protected  ManuscriptBase(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public abstract void Print();
    }

    public class Book : ManuscriptBase
    {
        public Book(IFormatter formatter) : base(formatter)
        {
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public override void Print()
        {
            Console.WriteLine(_formatter.Format("Title", Title));
            Console.WriteLine(_formatter.Format("Author", Author));
            Console.WriteLine(_formatter.Format("Text", Text));
            Console.WriteLine();
        }
    }

    public class FAQ : ManuscriptBase
    {
        public string Title { get; set; }
        public Dictionary<string, string> Questions { get; set; }

        public FAQ(IFormatter formatter) : base(formatter)
        {
            Questions = new Dictionary<string, string>();
        }

        public override void Print()
        {
            Console.WriteLine(_formatter.Format("Title", Title));
            foreach (var question in Questions)
            {
                Console.WriteLine(_formatter.Format("   Question", question.Key));
                Console.WriteLine(_formatter.Format("   Answer", question.Value));
            }
            Console.WriteLine();
        }
    }

    public class TermPaper : ManuscriptBase
    {
        public TermPaper(IFormatter formatter) : base(formatter)
        {
        }

        public string Class { get; set; }
        public string Student { get; set; }
        public string Text { get; set; }
        public string References { get; set; }

        public override void Print()
        {
            Console.WriteLine(_formatter.Format("Class", Class));
            Console.WriteLine(_formatter.Format("Student", Student));
            Console.WriteLine(_formatter.Format("Text", Text));
            Console.WriteLine(_formatter.Format("References", References));
            Console.WriteLine();
        }
    }

}
