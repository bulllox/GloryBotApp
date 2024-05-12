using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using GloryBotApp.ViewModels;

namespace GloryBotApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainLoading_OnValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        if (e.NewValue >= MainLoading.Maximum)
        {
            var appWindow = new ApplicationWindow();
            appWindow.DataContext = new ApplicationWindowViewModel();
            appWindow.Show();
            this.Close();
        }
    }
}