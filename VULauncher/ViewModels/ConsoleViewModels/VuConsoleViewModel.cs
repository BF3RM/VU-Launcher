using VULauncher.ViewModels.Common;
using VULauncher.Views.DockingAdapter;

namespace VULauncher.ViewModels.ConsoleViewModels
{
    public class VuConsoleViewModel : DockingViewModel
    {
        public VuConsoleViewModel(string consoleName)
        {
            Header = consoleName;
            State = DockState.Document;
        }
    }
}
