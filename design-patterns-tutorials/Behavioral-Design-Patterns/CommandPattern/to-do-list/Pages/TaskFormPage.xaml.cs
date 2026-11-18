using to_do_list.ViewModels;

namespace to_do_list;

public partial class TaskFormPage : ContentPage
{
	private readonly TaskFormViewModel _viewModel;
	public TaskFormPage(TaskFormViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
	private async Task SaveCommand()
	{
		await _viewModel.OnSaveTask();
	}
}