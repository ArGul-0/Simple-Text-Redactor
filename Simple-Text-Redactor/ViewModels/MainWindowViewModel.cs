using CommunityToolkit.Mvvm.Input;
using Simple_Text_Redactor.Application.Services;

namespace Simple_Text_Redactor.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IWindowService windowService;

    public MainWindowViewModel(IWindowService windowService)
    {
        this.windowService = windowService;
    }
    
    [RelayCommand]
    private void OpenRedactor()
    {
        windowService.OpenRedactorWindow();
    }
}