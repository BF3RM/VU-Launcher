using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Items.Common
{
    public class ValidationError
    {
        public string Message { get; set; }

        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
