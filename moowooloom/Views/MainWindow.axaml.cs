using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using moowooloom.ViewModels;
using ReactiveUI;

namespace moowooloom.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(action => 
            action(ViewModel!.ShowEditWADsWindow.RegisterHandler(MenuButtonEditWADs_OnClick)));
    }

    private void MenuButtonExit_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
        {
            lifetime.Shutdown();
        }
    }

    private async Task MenuButtonEditWADs_OnClick(InteractionContext<EditWADsViewModel, WADEditorViewModel?> interaction)
    {
        var dialog = new EditWADsWindow();
        dialog.DataContext = interaction.Input;
        
        var result = await dialog.ShowDialog<WADEditorViewModel?>(this);
        interaction.SetOutput(result);
    }
}