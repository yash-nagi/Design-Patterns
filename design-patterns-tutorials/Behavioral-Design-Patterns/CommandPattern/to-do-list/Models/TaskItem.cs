
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace to_do_list.Models;

public class TaskItem : INotifyPropertyChanged
{
    private string _title = string.Empty;
    private string _notes = string.Empty;
    private DateTime _dueDate = DateTime.Today;
    private TimeSpan _dueTime = TimeSpan.Zero;
    private string _priority = "Medium";
    private string _category = "Personal";
    private bool _reminderEnabled;

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public DateTime DueDate
    {
        get => _dueDate;
        set
        {
            if (SetProperty(ref _dueDate, value))
                OnPropertyChanged(nameof(DueDateText));
        }
    }

    public TimeSpan DueTime
    {
        get => _dueTime;
        set
        {
            if (SetProperty(ref _dueTime, value))
                OnPropertyChanged(nameof(ScheduleText));
        }
    }

    public string Priority
    {
        get => _priority;
        set => SetProperty(ref _priority, value);
    }

    public string Category
    {
        get => _category;
        set => SetProperty(ref _category, value);
    }

    public bool ReminderEnabled
    {
        get => _reminderEnabled;
        set
        {
            if (SetProperty(ref _reminderEnabled, value))
                OnPropertyChanged(nameof(ReminderText));
        }
    }

    public ObservableCollection<SubTask> Subtasks { get; set; } = new();

    // Properties used for UI display

    public string ScheduleText =>
        $"{DueTime:hh\\:mm} · {Category}";

    public string DueDateText =>
        DueDate.Date == DateTime.Today
            ? $"Today, {DueTime:hh\\:mm}"
            : $"{DueDate:dd MMM yyyy}, {DueTime:hh\\:mm}";

    public string ReminderText =>
        ReminderEnabled ? "30 minutes before" : "No reminder";

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(
        ref T backingField,
        T value,
        [CallerMemberName] string? propertyName = null)
    {
        if (Equals(backingField, value))
            return false;

        backingField = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
