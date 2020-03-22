using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VULauncher.Views.Dialogs;

namespace VULauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
#if DEBUG
            if (e.Exception.GetType() == typeof(ResourceReferenceKeyNotFoundException)) // This happens when editing a StaticResource in the XAML designer while the program is running
            {
                return;
            }
#endif
            ExceptionViewer ev = new ExceptionViewer($"Unhandled Exception: {e.Exception.Message}", e.Exception);
            ev.ShowDialog();
            //MessageBox.Show(e.Exception.StackTrace, $"Unhandled Exception: {e.Exception.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
