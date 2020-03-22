using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels.ConsoleViewModels
{
    public class VuConsoleViewModel : DockableDocumentViewModel
    {
        public VuConsoleViewModel(string consoleName)
        {
            Title = consoleName;
        }
    }
}
