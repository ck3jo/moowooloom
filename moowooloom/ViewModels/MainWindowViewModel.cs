using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace moowooloom.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public Interaction<EditWADsViewModel, WADEditorViewModel> ShowEditWADsWindow { get; }
    public ICommand ShowEditWADsCommand { get; }
    
    public MainWindowViewModel()
    {
        ShowEditWADsWindow = new Interaction<EditWADsViewModel, WADEditorViewModel>();
        ShowEditWADsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var ShowWADs = new EditWADsViewModel();
            var result = await ShowEditWADsWindow.Handle(ShowWADs);
        });
    }
}