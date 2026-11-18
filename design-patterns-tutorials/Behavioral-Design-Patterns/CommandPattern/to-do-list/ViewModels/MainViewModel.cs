using System.Windows.Input;

namespace to_do_list.ViewModels;

public class MainViewModel
{
    public ICommand CreateCommand { get; }

    public MainViewModel()
    {
        CreateCommand = new Command(OnCreateTask);
    }

    private async void OnCreateTask()
    {
        await Shell.Current.GoToAsync(nameof(TaskFormPage));
    }
}