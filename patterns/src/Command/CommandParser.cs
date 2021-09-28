using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    public class CommandParser
    {
        readonly IEnumerable<ICommandFactory> _availableCommands;
        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            _availableCommands = availableCommands;
        }
        public ICommand ParseCommand(string[] args)
        {
            ICommandFactory commandFactory = FindRequestCommand(args[0]);
            if (commandFactory is null)
                return new NotFoundCommand();
            return commandFactory.MakeCommand(args);
        }

        private ICommandFactory FindRequestCommand(string name)
            => _availableCommands.FirstOrDefault(v => v.CommandName == name);
    }
}
