using Avalonia.Controls;
using Simple_Text_Redactor.ViewModels;

namespace Simple_Text_Redactor.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (DataContext is MainWindowViewModel viewModel)
        {
            viewModel.RequestClose += () => Close();
        }
    }
}