using System.Collections.ObjectModel;
using System.Windows.Input;
using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.ViewModels;

public class MainViewModel
{
    private readonly ITaskService _taskService;
    private readonly IOperations _operations;

    public ObservableCollection<TaskItem> Tasks { get; } = new();
    public ICommand CreateCommand { get; }
    public ICommand OpenTaskCommand { get; }

    public MainViewModel(ITaskService taskService, IOperations operations)
    {
        _taskService = taskService;
        _operations = operations;
        CreateCommand = new Command(async () => await OnCreateTaskClicked());
        OpenTaskCommand = new Command<TaskItem>(async (task) => await ViewTaskDetails(task));
    }

    public async Task LoadTasksAsync()
    {
        var tasks = await _taskService.GetAllTasksAsync();

        Tasks.Clear();

        foreach (var task in tasks)
        {
            Tasks.Add(task);
        }
    }
    private async Task OnCreateTaskClicked()
    {
        await Shell.Current.GoToAsync(nameof(TaskFormPage));
    }
    private async Task ViewTaskDetails(TaskItem task)
    {
        if (task == null)
            return;

        await Shell.Current.GoToAsync($"{nameof(TaskDetailPage)}?taskId={task.Id}");
    }
}