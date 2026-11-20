using to_do_list.Models;
using to_do_list.ViewModels;

namespace to_do_list;

public partial class TaskFormPage : ContentPage, IQueryAttributable
{
	private readonly TaskFormViewModel _viewModel;
	public TaskFormPage(TaskFormViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if (query.TryGetValue("TaskItem", out var value)
			&& value is TaskItem task)
		{
			_viewModel.LoadTask(task);
		}
	}
}