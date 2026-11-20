using System.Collections.ObjectModel;
using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.Commands;

public sealed class UpdateTaskCommand : IApplicationCommand
{
    private readonly ITaskService _taskService;
    private readonly TaskItem _target;
    private readonly TaskItem _before;
    private readonly TaskItem _after;

    public UpdateTaskCommand(
        ITaskService taskService,
        TaskItem target,
        TaskItem before,
        TaskItem after)
    {
        _taskService = taskService;
        _target = target;
        _before = Clone(before);
        _after = Clone(after);
    }

    public async Task ExecuteAsync()
    {
        Copy(_after, _target);
        await _taskService.UpdateTaskAsync(_target);
    }

    public async Task UndoAsync()
    {
        Copy(_before, _target);
        await _taskService.UpdateTaskAsync(_target);
    }

    private static void Copy(TaskItem source, TaskItem target)
    {
        target.Title = source.Title;
        target.Notes = source.Notes;
        target.DueDate = source.DueDate;
        target.DueTime = source.DueTime;
        target.Priority = source.Priority;
        target.Category = source.Category;
        target.ReminderEnabled = source.ReminderEnabled;
        target.Subtasks.Clear();

        foreach (var subtask in source.Subtasks)
        {
            target.Subtasks.Add(new SubTask
            {
                Id = subtask.Id,
                Title = subtask.Title,
                IsCompleted = subtask.IsCompleted
            });
        }
    }

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
