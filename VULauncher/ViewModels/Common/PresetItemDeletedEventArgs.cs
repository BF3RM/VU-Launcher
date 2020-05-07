using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Common
{
    public class PresetItemDeletedEventArgs : EventArgs
    {
        public int DeletedPresetId { get; set; }

        public PresetItemDeletedEventArgs(int deletedPresetId)
        {
            DeletedPresetId = deletedPresetId;
        }
    }
}
