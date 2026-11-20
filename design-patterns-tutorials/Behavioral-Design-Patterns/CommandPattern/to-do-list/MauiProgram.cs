using Microsoft.Extensions.Logging;
using to_do_list.Services;
using to_do_list.ViewModels;
#if MAUI_DEVFLOW
using Microsoft.Maui.DevFlow.Agent;
#endif

namespace to_do_list;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<AppShell>();
		builder.Services.AddSingleton<ITaskService, TaskService>();
		builder.Services.AddSingleton<IOperations, Operations>();
		builder.Services.AddSingleton<CommandInvoker>();

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<TaskFormViewModel>();
		builder.Services.AddTransient<TaskDetailViewModel>();

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<TaskFormPage>();
		builder.Services.AddTransient<TaskDetailPage>();
#if MAUI_DEVFLOW
		builder.AddMauiDevFlowAgent();
#endif
		return builder.Build();
	}
}
