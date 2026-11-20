using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using to_do_list.Models;
using to_do_list.Services;
using to_do_list.Commands;

namespace to_do_list.ViewModels;

public class TaskDetailViewModel : INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    private readonly CommandInvoker _commandInvoker;
    public event PropertyChangedEventHandler? PropertyChanged;
    public ICommand BackCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ToggleSubtaskCommand { get; }
    public ICommand UndoCommand { get; }
    public ICommand RedoCommand { get; }
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
    private bool _isEditMode;

    public bool IsEditMode
    {
        get => _isEditMode;
        set
        {
            _isEditMode = value;
            OnPropertyChanged();
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
    public TaskDetailViewModel(
        ITaskService taskService,
        CommandInvoker commandInvoker)
    {
        _taskService = taskService;
        _commandInvoker = commandInvoker;
        BackCommand = new Command(async () => await GoBack());
        EditCommand = new Command<TaskItem>(async (task) => await EditTask(task));
        DeleteCommand = new Command(async () => await DeleteTask());
        ToggleSubtaskCommand = new Command<SubTask>(
            async (subtask) => await ToggleSubtask(subtask));
        UndoCommand = new Command(async () => await Undo());
        RedoCommand = new Command(async () => await Redo());
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
                    OnPropertyChanged(nameof(SubtaskProgress));
            };
        }
        IsEditMode = true;
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
    private async Task EditTask(TaskItem task)
    {
        if (task == null)
            return;

        var parameters = new Dictionary<string, object>
        {
            { "TaskItem", task }
        };
        await Shell.Current.GoToAsync(nameof(TaskFormPage), parameters);
    }
    private async Task DeleteTask()
    {
        if (!IsEditMode || TaskItem == null)
            return;

        bool confirm = await Shell.Current.DisplayAlertAsync(
            "Delete Task",
            "Are you sure you want to delete this task?",
            "Yes",
            "No");

        if (!confirm)
            return;

        try
        {
            await _commandInvoker.ExecuteAsync(
                new DeleteTaskCommand(_taskService, TaskItem));

            await Shell.Current.DisplayAlertAsync(
                "Deleted",
                "Task deleted successfully.",
                "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync(
                "Error",
                $"Unable to delete task: {ex.Message}",
                "OK");
        }
    }
    private async Task ToggleSubtask(SubTask subtask)
    {
        if (TaskItem == null)
            return;

        await _commandInvoker.ExecuteAsync(
            new ToggleSubtaskCommand(
                _taskService,
                TaskItem,
                subtask,
                !subtask.IsCompleted));

        OnPropertyChanged(nameof(SubtaskProgress));
    }
    private async Task Undo()
    {
        await _commandInvoker.UndoAsync();
        OnPropertyChanged(nameof(SubtaskProgress));
    }
    private async Task Redo()
    {
        await _commandInvoker.RedoAsync();
        OnPropertyChanged(nameof(SubtaskProgress));
    }
}