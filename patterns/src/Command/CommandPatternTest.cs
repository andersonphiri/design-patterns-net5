using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class CommandPatternTest
    {
        public void Run(string[] args)
        {
            _commands = _commands ?? GetAvailableCommands();
            var parser = new CommandParser(_commands);
            var command = parser.ParseCommand(args);
            command?.Execute();
        }
        private IEnumerable<ICommandFactory> _commands;

        static IEnumerable<ICommandFactory> GetAvailableCommands()
            => new ICommandFactory[] { new DoStuffCommand() };
    }
}
