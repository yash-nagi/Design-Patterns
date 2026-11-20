using to_do_list.ViewModels;

namespace to_do_list;

public partial class TaskDetailPage : ContentPage, IQueryAttributable
{
	private readonly TaskDetailViewModel _viewModel;
	public TaskDetailPage(TaskDetailViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
	public async void ApplyQueryAttributes(
		IDictionary<string, object> query)
	{
		try
		{
			if (query.TryGetValue("taskId", out var value)
				&& Guid.TryParse(value?.ToString(), out Guid taskId))
			{
				await _viewModel.LoadTaskAsync(taskId);
			}
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Error", ex.Message, "OK");
		}
	}
}