using System;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Simple_Text_Redactor.Application.Services;
using Simple_Text_Redactor.ViewModels;
using Simple_Text_Redactor.Views;

namespace Simple_Text_Redactor;

public partial class App : Avalonia.Application
{
    public static IServiceProvider? Services { get; private set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        var services = new ServiceCollection();
        
        // Views
        services.AddTransient<MainWindow>();
        services.AddTransient<RedactorWindow>();
        
        // View Models
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<RedactorViewModel>();
        
        // Services
        services.AddSingleton<IWindowService, WindowService>();
        
        // Use Cases
        
        Services = services.BuildServiceProvider();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = Services!.GetRequiredService<MainWindow>();
            mainWindow.DataContext = Services!.GetRequiredService<MainWindowViewModel>(); 
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}