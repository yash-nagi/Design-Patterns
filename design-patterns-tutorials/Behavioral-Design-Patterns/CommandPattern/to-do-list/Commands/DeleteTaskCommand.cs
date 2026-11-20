using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.Commands;

public sealed class DeleteTaskCommand : IApplicationCommand
{
    private readonly ITaskService _taskService;
    private readonly TaskItem _task;

    public DeleteTaskCommand(ITaskService taskService, TaskItem task)
    {
        _taskService = taskService;
        _task = Clone(task);
    }

    public Task ExecuteAsync() => _taskService.DeleteTaskAsync(_task.Id);

    public Task UndoAsync() => _taskService.CreateTaskAsync(Clone(_task));

    private static TaskItem Clone(TaskItem task)
    {
        var clone = new TaskItem
        {
            Id = task.Id,
            Title = task.Title,
            Notes = task.Notes,
            DueDate = task.DueDate,
            DueTime = task.DueTime,
            Priority = task.Priority,
            Category = task.Category,
            ReminderEnabled = task.ReminderEnabled
        };

        foreach (var subtask in task.Subtasks)
        {
            clone.Subtasks.Add(new SubTask
            {
                Id = subtask.Id,
                Title = subtask.Title,
                IsCompleted = subtask.IsCompleted
            });
        }

        return clone;
    }
}
