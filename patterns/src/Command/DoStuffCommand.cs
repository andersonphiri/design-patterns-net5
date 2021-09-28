using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class DoStuffCommand : ICommand, ICommandFactory
    {
        public string CommandName { get => nameof(DoStuffCommand); }

        public string Description { get => "Does stuff"; }

        public string Value { get; private set; }

        public void Execute()
        {
            Console.WriteLine("Doing stuff...");
            Console.WriteLine("Doing stuff completed...");
        }

        public ICommand MakeCommand(string[] args)
        {
            return new DoStuffCommand { Value = args[1] };
        }
    }

    public class NotFoundCommand : ICommand
    {
        public string Name { get => nameof(NotFoundCommand);  }
        public void Execute()
        {
            Console.WriteLine("Not found Command");
        }
    }
}
