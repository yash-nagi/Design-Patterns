namespace to_do_list;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(TaskFormPage), typeof(TaskFormPage));
		Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
	}
}
