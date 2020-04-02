using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.Models.PresetProviders.Common
{
    public interface IPresetsProvider<TPresetItem>
    {
        List<TPresetItem> PresetItems { get; }
        void Save(IEnumerable<TPresetItem> presetItems);
        TPresetItem FindPresetItemById(int id);
    }
}
