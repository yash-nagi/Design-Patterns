using System.Windows.Input;
using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.ViewModels;

public class TaskFormViewModel
{
    private readonly ITaskService _taskService;
    private readonly IOperations _operations;
    public TaskItem _taskItem { get; set; } = new();

    public ICommand SaveCommand { get; }
    public TaskFormViewModel(ITaskService taskService, IOperations operations)
    {
        _taskService = taskService;
        _operations = operations;

        SaveCommand = new Command(async () => await OnSaveTask());
    }
    public async Task OnSaveTask()
    {
        if (string.IsNullOrEmpty(_taskItem.Title))
            return;
        // Create task item template.
        TaskItem taskItem = _operations.CreateTask(_taskItem.Title,
                                                   _taskItem.Notes,
                                                   _taskItem.Priority,
                                                   _taskItem.Category,
                                                   _taskItem.ReminderEnabled);
        // Save task item into json.
        await _taskService.CreateTaskAsync(taskItem);
        await Shell.Current.GoToAsync("..");
    }
    private async void OnCancelTask()
    {
        await Shell.Current.GoToAsync("..");
    }
}