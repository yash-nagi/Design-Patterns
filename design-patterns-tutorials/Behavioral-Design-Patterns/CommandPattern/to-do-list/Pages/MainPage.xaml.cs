using to_do_list.ViewModels;

namespace to_do_list;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
	private async void OnCreateTaskClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(TaskFormPage));
	}
}
