using System;

namespace VULauncher.ViewModels.Common
{
    public interface IErrorHandler
    {
        void HandleException(Exception ex);
    }
}
