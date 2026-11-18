using System.Windows.Input;

namespace to_do_list.ViewModels;

public class TaskFormPage
{
    public ICommand SaveCommand { get; }
    public ICommand CancelComand { get; }
    public TaskFormPage()
    {
        SaveCommand = new Command(OnSaveTask);
        CancelComand = new Command(OnCancelTask);
    }
    private async void OnSaveTask()
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
    private async void OnCancelTask()
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}