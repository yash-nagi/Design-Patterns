using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.Commands;

public sealed class AddSubtaskCommand : IApplicationCommand
{
    private readonly ITaskService? _taskService;
    private readonly TaskItem _task;
    private readonly SubTask _subtask;

    public AddSubtaskCommand(ITaskService? taskService, TaskItem task, string title)
    {
        _taskService = taskService;
        _task = task;
        _subtask = new SubTask
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            IsCompleted = false
        };
    }

    public async Task ExecuteAsync()
    {
        if (!_task.Subtasks.Contains(_subtask))
            _task.Subtasks.Add(_subtask);

        if (_taskService != null)
            await _taskService.UpdateTaskAsync(_task);
    }

    public async Task UndoAsync()
    {
        _task.Subtasks.Remove(_subtask);

        if (_taskService != null)
            await _taskService.UpdateTaskAsync(_task);
    }
}
