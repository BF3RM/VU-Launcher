using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Common
{
    public interface ITabViewModel
    {
        event TabIndexChangedEventHandler TabIndexChanged;
    }
}
