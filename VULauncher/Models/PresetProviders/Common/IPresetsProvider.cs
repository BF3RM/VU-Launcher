using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.Models.PresetProviders.Common
{
    public interface IPresetsProvider<TPresetItem>
    {
        List<TPresetItem> PresetItems { get; }
        void ReloadPresetItems();
        void Save(IEnumerable<TPresetItem> presetItems);
        TPresetItem CreateEmptyPresetItem(string presetName);
    }
}
