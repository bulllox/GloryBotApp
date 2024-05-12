using CommunityToolkit.Mvvm.ComponentModel;

namespace GloryBotApp.ViewModels;

public partial class ApplicationWindowViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isMenuOpen = true;

    public void OpenMenu()
    {
        IsMenuOpen = !IsMenuOpen;
    }
}