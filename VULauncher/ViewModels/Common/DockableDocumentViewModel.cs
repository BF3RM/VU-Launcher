using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VULauncher.Commands;
using Xceed.Wpf.AvalonDock.Controls;

namespace VULauncher.ViewModels.Common
{
    public class DockableDocumentViewModel : ViewModel
    {
        private bool _isClosed;
        private bool _canClose = true;
        private string _title;

        public ICommand CloseCommand { get; }

        public DockableDocumentViewModel()
        {
            CloseCommand = new RelayCommand(x =>
            {
                IsClosed = true;
            });


            this.CanClose = true;
        }

        public bool IsClosed
        {
            get => _isClosed;
            set => SetField(ref _isClosed, value);
        }

        public bool CanClose
        {
            get => _canClose;
            set => SetField(ref _canClose, value);
        }

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }
    }
}
