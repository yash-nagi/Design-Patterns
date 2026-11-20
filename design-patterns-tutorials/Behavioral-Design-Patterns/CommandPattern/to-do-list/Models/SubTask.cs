
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace to_do_list.Models;

public class SubTask : INotifyPropertyChanged
{
    private string _id = string.Empty;
    private string _title = string.Empty;
    private bool _isCompleted;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public bool IsCompleted
    {
        get => _isCompleted;
        set
        {
            if (_isCompleted == value)
                return;

            _isCompleted = value;
            OnPropertyChanged();
        }
    }
    public string Id
    {
        get => _id;
        set
        {
            if (_id == value)
                return;

            _id = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}