namespace to_do_list.Commands;

public interface IApplicationCommand
{
    Task ExecuteAsync();
    Task UndoAsync();
}
