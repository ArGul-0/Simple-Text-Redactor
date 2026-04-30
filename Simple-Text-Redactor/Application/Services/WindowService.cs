using System;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Extensions.DependencyInjection;
using Simple_Text_Redactor.ViewModels;
using Simple_Text_Redactor.Views;

namespace Simple_Text_Redactor.Application.Services;

public class WindowService : IWindowService
{
    private readonly IServiceProvider services;
    
    public WindowService(IServiceProvider services)
    {
        this.services = services;
    }
    
    public void OpenRedactorWindow(string? filePath = null)
    {
        if(Avalonia.Application.Current?.ApplicationLifetime
           is not IClassicDesktopStyleApplicationLifetime desktop)
            throw new InvalidOperationException("Application is not running in desktop mode");

        var redactorWindow = services.GetRequiredService<RedactorWindow>();
        var redactorVm = services.GetRequiredService<RedactorViewModel>();
        
        // if(filePath is not null) Х
            // redactorVm.LoadFile(filePath); Not implemented yet
            
        redactorWindow.DataContext = redactorVm;
            
        var oldWindow = desktop.MainWindow;
        
        desktop.MainWindow = redactorWindow;
        redactorWindow.Show();
        
        oldWindow?.Close();    
    }
}