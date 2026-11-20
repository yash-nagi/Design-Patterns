using System.Collections.ObjectModel;
using System.Windows.Input;
using to_do_list.Models;
using to_do_list.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace to_do_list.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    private readonly CommandInvoker _commandInvoker;

    public ObservableCollection<TaskItem> Tasks { get; } = new();
    public ICommand CreateCommand { get; }
    public ICommand OpenTaskCommand { get; }
    public ICommand UndoCommand { get; }
    public ICommand RedoCommand { get; }
    public event PropertyChangedEventHandler? PropertyChanged;

    public string CurrentDate =>
        DateTime.Today.ToString("dddd, dd MMMM");

    public string ProgressText =>
        $"{CompletedTaskCount}/{Tasks.Count} Completed";

    public string RemainingText =>
        Tasks.Count == 0
            ? "No tasks"
            : $"{Tasks.Count - CompletedTaskCount} remaining";

    public double Progress =>
        Tasks.Count == 0
            ? 0
            : (double)CompletedTaskCount / Tasks.Count;

    private int CompletedTaskCount =>
        Tasks.Count(task =>
            task.Subtasks.Count > 0 &&
            task.Subtasks.All(subtask => subtask.IsCompleted));

    public MainViewModel(
        ITaskService taskService,
        CommandInvoker commandInvoker)
    {
        _taskService = taskService;
        _commandInvoker = commandInvoker;
        CreateCommand = new Command(async () => await OnCreateTaskClicked());
        OpenTaskCommand = new Command<TaskItem>(async (task) => await ViewTaskDetails(task));
        UndoCommand = new Command(async () => await Undo());
        RedoCommand = new Command(async () => await Redo());
        Tasks.CollectionChanged += (_, _) => OnProgressChanged();
    }

    public async Task LoadTasksAsync()
    {
        var tasks = await _taskService.GetAllTasksAsync();

        Tasks.Clear();

        foreach (var task in tasks)
        {
            Tasks.Add(task);
        }

        OnProgressChanged();
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
    private async Task Undo()
    {
        await _commandInvoker.UndoAsync();
        await LoadTasksAsync();
    }
    private async Task Redo()
    {
        await _commandInvoker.RedoAsync();
        await LoadTasksAsync();
    }
    private void OnProgressChanged()
    {
        OnPropertyChanged(nameof(ProgressText));
        OnPropertyChanged(nameof(RemainingText));
        OnPropertyChanged(nameof(Progress));
    }
    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}