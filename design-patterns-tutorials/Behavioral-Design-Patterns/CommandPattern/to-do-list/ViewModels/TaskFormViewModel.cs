using System.Windows.Input;
using to_do_list.Models;
using to_do_list.Services;
using System.ComponentModel;

namespace to_do_list.ViewModels;

public class TaskFormViewModel : INotifyPropertyChanged
{
    private readonly ITaskService _taskService;
    private readonly IOperations _operations;
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
    private string _newSubtaskTitle = string.Empty;

    public string NewSubtaskTitle
    {
        get => _newSubtaskTitle;
        set
        {
            _newSubtaskTitle = value;
            OnPropertyChanged(NewSubtaskTitle);
        }
    }
    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand AddSubtaskCommand { get; }
    public event PropertyChangedEventHandler? PropertyChanged;
    public TaskFormViewModel(ITaskService taskService, IOperations operations)
    {
        _taskService = taskService;
        _operations = operations;

        SaveCommand = new Command(async () => await OnSaveTask());
        CancelCommand = new Command(async () => await OnCancelTask());
        AddSubtaskCommand = new Command(async () => await AddSubtask());
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
                                                   _taskItem.ReminderEnabled,
                                                   _taskItem.DueDate,
                                                   _taskItem.DueTime);
        // Adding subtasks.
        foreach (var subtask in _taskItem.Subtasks)
        {
            taskItem.Subtasks.Add(subtask);
        }
        // Save task item into json.
        await _taskService.CreateTaskAsync(taskItem);
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

        _taskItem.Subtasks.Add(new SubTask
        {
            Title = title,
            IsCompleted = false
        });

        NewSubtaskTitle = string.Empty;

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
}