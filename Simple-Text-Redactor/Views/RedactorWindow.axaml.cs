using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Simple_Text_Redactor.ViewModels;

namespace Simple_Text_Redactor.Views;

public partial class RedactorWindow : Window
{
    public RedactorWindow()
    {
        InitializeComponent();

        DataContext = App.Services!.GetRequiredService<RedactorViewModel>();
    }
}