using System;
using CommunityToolkit.Mvvm.Input;
using Simple_Text_Redactor.Views;

namespace Simple_Text_Redactor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public event Action? RequestClose;
    
    [RelayCommand]
    private void OpenRedactor()
    {
        RedactorWindow window = new RedactorWindow();
        window.Show();
        
        RequestClose?.Invoke();
    }
}