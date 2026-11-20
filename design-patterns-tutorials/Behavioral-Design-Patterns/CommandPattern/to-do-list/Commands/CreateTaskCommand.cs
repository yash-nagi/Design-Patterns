using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.Commands;

public sealed class CreateTaskCommand : IApplicationCommand
{
    private readonly ITaskService _taskService;
    private readonly TaskItem _task;

    public CreateTaskCommand(ITaskService taskService, TaskItem task)
    {
        _taskService = taskService;
        _task = task;
    }

    public Task ExecuteAsync() => _taskService.CreateTaskAsync(_task);

    public Task UndoAsync() => _taskService.DeleteTaskAsync(_task.Id);
}
