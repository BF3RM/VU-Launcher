using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Sentry;
using VULauncher.Views.Dialogs;

namespace VULauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SentrySdk.Init(o =>
            {
                // Tells which project in Sentry to send events to:
                o.Dsn = "https://416f3eba7df64f8082dcff04f7033a72@o384901.ingest.sentry.io/6140538";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = 1.0;
            });
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
#if DEBUG
            if (e.Exception.GetType() ==
                typeof(ResourceReferenceKeyNotFoundException)) // This happens when editing a StaticResource in the XAML designer while the program is running
            {
                return;
            }
#endif
            SentrySdk.CaptureException(e.Exception);

            ExceptionViewer ev = new ExceptionViewer($"Unhandled Exception: {e.Exception.Message}", e.Exception);
            ev.ShowDialog();
            //MessageBox.Show(e.Exception.StackTrace, $"Unhandled Exception: {e.Exception.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
