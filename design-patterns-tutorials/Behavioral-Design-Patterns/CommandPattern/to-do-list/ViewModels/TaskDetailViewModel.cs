using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using to_do_list.Models;
using to_do_list.Services;

namespace to_do_list.ViewModels;

public class TaskDetailViewModel : INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    private readonly IOperations _operations;
    public event PropertyChangedEventHandler? PropertyChanged;
    public ICommand BackCommand { get; }
    public ICommand EditCommand { get; }
    public TaskItem? _taskItem { get; private set; }
    public TaskItem? TaskItem
    {
        get => _taskItem;
        private set
        {
            _taskItem = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SubtaskProgress));
        }
    }
    public string SubtaskProgress
    {
        get
        {
            if (TaskItem?.Subtasks == null)
                return "0/0 completed";

            int total = TaskItem.Subtasks.Count;
            int completed = TaskItem.Subtasks.Count(x => x.IsCompleted);

            return $"{completed}/{total} completed";
        }
    }
    public TaskDetailViewModel(ITaskService taskService, IOperations operations)
    {
        _taskService = taskService;
        _operations = operations;
        BackCommand = new Command(async () => await GoBack());
        EditCommand = new Command(async () => await EditTask());
    }
    public async Task LoadTaskAsync(Guid taskId)
    {
        TaskItem = await _taskService.GetTaskByIdAsync(taskId);

        if (TaskItem == null)
            return;

        foreach (var subtask in TaskItem.Subtasks)
        {
            subtask.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName == nameof(SubTask.IsCompleted))
                {
                    OnPropertyChanged(nameof(SubtaskProgress));

                    // Persist the updated task.
                    MainThread.BeginInvokeOnMainThread(
                        async () => await _taskService.UpdateTaskAsync(TaskItem));
                }
            };
        }
    }
    protected void OnPropertyChanged(
         [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    private async Task EditTask()
    {

    }
}