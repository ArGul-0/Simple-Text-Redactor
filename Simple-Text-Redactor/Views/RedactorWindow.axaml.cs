using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Simple_Text_Redactor.ViewModels;

namespace Simple_Text_Redactor.Views;

public partial class RedactorWindow : Window
{
    public RedactorWindow()
    {
        InitializeComponent();
        DataContext = new RedactorViewModel();
    }
}