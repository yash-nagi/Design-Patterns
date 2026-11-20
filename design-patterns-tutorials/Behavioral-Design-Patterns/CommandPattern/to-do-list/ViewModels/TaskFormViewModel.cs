using System.Windows.Input;
using to_do_list.Models;
using to_do_list.Services;
using to_do_list.Commands;
using System.ComponentModel;

namespace to_do_list.ViewModels;

public class TaskFormViewModel : INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    private readonly IOperations _operations;
    private readonly CommandInvoker _commandInvoker;
    private TaskItem? _originalTask;
    public TaskItem _taskItem { get; set; } = new();
    public List<string> Priorities { get; set; } =
    [
        "Low",
        "Medium",
        "High",
        "Critical"
    ];
    public string Proority { get; set; } = "Medium";
    public List<string> Categories { get; set; } =
    [
        "Personal",
        "Work",
        "Study",
        "Health",
        "Shopping",
        "Other"
    ];
    public string Category { get; set; } = "Personal";
    private bool _isEditMode;

    public bool IsEditMode
    {
        get => _isEditMode;
        private set
        {
            _isEditMode = value;
            OnPropertyChanged(nameof(IsEditMode));
            OnPropertyChanged(nameof(SaveButtonText));
            OnPropertyChanged(nameof(PageTitle));
        }
    }

    public string SaveButtonText => IsEditMode ? "Update" : "Add";

    public string PageTitle => IsEditMode ? "Edit Task" : "Add Task";
    private string _newSubtaskTitle = string.Empty;

    public string NewSubtaskTitle
    {
        get => _newSubtaskTitle;
        set
        {
            _newSubtaskTitle = value;
            OnPropertyChanged(nameof(NewSubtaskTitle));
        }
    }
    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand AddSubtaskCommand { get; }
    public ICommand UndoCommand { get; }
    public ICommand RedoCommand { get; }
    public event PropertyChangedEventHandler? PropertyChanged;
    public TaskFormViewModel(
        ITaskService taskService,
        IOperations operations,
        CommandInvoker commandInvoker)
    {
        _taskService = taskService;
        _operations = operations;
        _commandInvoker = commandInvoker;

        SaveCommand = new Command(async () => await OnSaveTask());
        CancelCommand = new Command(async () => await OnCancelTask());
        AddSubtaskCommand = new Command(async () => await AddSubtask());
        UndoCommand = new Command(async () => await Undo());
        RedoCommand = new Command(async () => await Redo());
    }
    public async Task OnSaveTask()
    {
        if (string.IsNullOrWhiteSpace(_taskItem.Title))
            return;

        if (IsEditMode)
        {
            if (_originalTask == null)
                return;

            var command = new UpdateTaskCommand(
                _taskService,
                _taskItem,
                _originalTask,
                Clone(_taskItem));

            await _commandInvoker.ExecuteAsync(command);
        }
        else
        {
            // Create new task
            TaskItem newTask = _operations.CreateTask(
                _taskItem.Title,
                _taskItem.Notes,
                _taskItem.Priority,
                _taskItem.Category,
                _taskItem.ReminderEnabled,
                _taskItem.DueDate,
                _taskItem.DueTime);

            foreach (var subtask in _taskItem.Subtasks)
            {
                newTask.Subtasks.Add(subtask);
            }

            await _commandInvoker.ExecuteAsync(
                new CreateTaskCommand(_taskService, newTask));
        }

        await Shell.Current.GoToAsync("..");
    }
    private async Task OnCancelTask()
    {
        await Shell.Current.GoToAsync("..");
    }
    private async Task AddSubtask()
    {
        string title = NewSubtaskTitle.Trim();

        if (string.IsNullOrWhiteSpace(title))
            return;

        await _commandInvoker.ExecuteAsync(
            new AddSubtaskCommand(
                IsEditMode ? _taskService : null,
                _taskItem,
                title));

        NewSubtaskTitle = string.Empty;

        OnPropertyChanged(nameof(IsSubtaskListEmpty));
    }
    private async Task Undo()
    {
        await _commandInvoker.UndoAsync();
        OnPropertyChanged(nameof(IsSubtaskListEmpty));
    }
    private async Task Redo()
    {
        await _commandInvoker.RedoAsync();
        OnPropertyChanged(nameof(IsSubtaskListEmpty));
    }
    public bool IsSubtaskListEmpty =>
        _taskItem.Subtasks.Count == 0;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
    public void LoadTask(TaskItem task)
    {
        _originalTask = Clone(task);
        _taskItem.Id = task.Id;
        _taskItem.Title = task.Title;
        _taskItem.Notes = task.Notes;
        _taskItem.DueDate = task.DueDate;
        _taskItem.DueTime = task.DueTime;
        _taskItem.Priority = task.Priority;
        _taskItem.Category = task.Category;
        _taskItem.ReminderEnabled = task.ReminderEnabled;

        _taskItem.Subtasks.Clear();

        foreach (var subtask in task.Subtasks)
        {
            _taskItem.Subtasks.Add(new SubTask
            {
                Id = subtask.Id,
                Title = subtask.Title,
                IsCompleted = subtask.IsCompleted
            });
        }

        IsEditMode = true;
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