namespace Command
{
    public interface ICommandFactory
    {
        string CommandName { get; }
        string Description { get; }

        ICommand MakeCommand(string[] args);
    }
}
