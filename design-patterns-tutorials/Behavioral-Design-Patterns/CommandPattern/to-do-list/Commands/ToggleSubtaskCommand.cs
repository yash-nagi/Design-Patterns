using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.Commands;

public sealed class ToggleSubtaskCommand : IApplicationCommand
{
    private readonly ITaskService _taskService;
    private readonly TaskItem _task;
    private readonly SubTask _subtask;
    private readonly bool _newValue;

    public ToggleSubtaskCommand(
        ITaskService taskService,
        TaskItem task,
        SubTask subtask,
        bool newValue)
    {
        _taskService = taskService;
        _task = task;
        _subtask = subtask;
        _newValue = newValue;
    }

    public async Task ExecuteAsync()
    {
        _subtask.IsCompleted = _newValue;
        await _taskService.UpdateTaskAsync(_task);
    }

    public async Task UndoAsync()
    {
        _subtask.IsCompleted = !_newValue;
        await _taskService.UpdateTaskAsync(_task);
    }
}
