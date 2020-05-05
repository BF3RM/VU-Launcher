using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.Models.PresetProviders.Common
{
    public interface IPresetsProvider<TPresetItem>
    {
	    IEnumerable<TPresetItem> LoadPresetItems();
        void Save(IEnumerable<TPresetItem> presetItems);
        TPresetItem CreateEmptyPresetItem(int presetId, string presetName);
    }
}
