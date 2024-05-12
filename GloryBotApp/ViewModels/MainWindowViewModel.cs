using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GloryBotApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private double _progressValue;

    private Timer _timer = new();

    public MainWindowViewModel()
    {
        ProgressValue = 0;
        _timer.Interval = 1000;
        _timer.Elapsed += OnTimerTick;
        _timer.Start();
    }

    private void OnTimerTick(object? sender, ElapsedEventArgs e)
    {
        ProgressValue += 10;
        if (ProgressValue == 100)
        {
            _timer.Stop();
        }
    }
}