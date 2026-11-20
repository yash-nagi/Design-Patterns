using to_do_list.Commands;

namespace to_do_list.Services;

public sealed class CommandInvoker
{
    private readonly Stack<IApplicationCommand> _undoStack = new();
    private readonly Stack<IApplicationCommand> _redoStack = new();

    public bool CanUndo => _undoStack.Count > 0;
    public bool CanRedo => _redoStack.Count > 0;

    public async Task ExecuteAsync(IApplicationCommand command)
    {
        await command.ExecuteAsync();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public async Task UndoAsync()
    {
        if (!CanUndo)
            return;

        var command = _undoStack.Pop();
        await command.UndoAsync();
        _redoStack.Push(command);
    }

    public async Task RedoAsync()
    {
        if (!CanRedo)
            return;

        var command = _redoStack.Pop();
        await command.ExecuteAsync();
        _undoStack.Push(command);
    }
}
