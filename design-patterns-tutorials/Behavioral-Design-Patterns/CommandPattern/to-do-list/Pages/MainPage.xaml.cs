using to_do_list.ViewModels;

namespace to_do_list;

public partial class MainPage : ContentPage
{
	private readonly MainViewModel _viewModel;

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		//await _viewModel.LoadTasksAsync();
		try
		{
			await _viewModel.LoadTasksAsync();
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(
				$"OnAppearing Error: {ex}");

			await DisplayAlert("Error", ex.Message, "OK");
		}
	}
	private async void CreateCommand()
	{
		await Shell.Current.GoToAsync(nameof(TaskFormPage));
	}
}
