using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using VULauncher.Models.Config;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.Models.PresetProviders.Common
{
    public abstract class PresetsProvider<TPresetEntity, TPresetItem> : IPresetsProvider<TPresetItem>
        where TPresetEntity : PresetEntity
        where TPresetItem : PresetItem
    {
        public List<TPresetItem> PresetItems { get; private set; }

        protected List<TPresetEntity> PresetEntities { get; set; }
        protected string CurrentDirectory => Path.Combine(Configuration.UserDataDirectory, SubDirectory);

        protected abstract string SubDirectory { get; }
        protected abstract IEnumerable<TPresetEntity> ConvertItemsToEntities(IEnumerable<TPresetItem> presetItems);
        protected abstract IEnumerable<TPresetItem> ConvertEntitiesToItems(IEnumerable<TPresetEntity> presetEntities);

        protected PresetsProvider()
        {
            Load();
        }

        private void Load()
        {
            PresetEntities = GetEntitiesFromFiles();
            PresetItems = ConvertEntitiesToItems(PresetEntities).ToList();
        }

        private List<TPresetEntity> GetEntitiesFromFiles()
        {
            if (!Directory.Exists(CurrentDirectory))
                Directory.CreateDirectory(CurrentDirectory);

            var entities = new List<TPresetEntity>();

            foreach (var filePath in Directory.GetFiles(CurrentDirectory, "*.json"))
            {
                entities.Add(JsonSerializer.Deserialize<TPresetEntity>(File.ReadAllText(filePath)));
            }

            return entities;
        }

        public void Save(IEnumerable<TPresetItem> presetItems)
        {
            var entities = ConvertItemsToEntities(presetItems);
            SaveEntities(entities);
        }

        private void SaveEntities(IEnumerable<TPresetEntity> presetEntities)
        {
            foreach (var presetEntity in presetEntities)
            {
                var jsonString = JsonSerializer.Serialize(presetEntity);
                var path = Path.Combine(CurrentDirectory, $"{presetEntity.Id}_{presetEntity.Name}.json");
                File.WriteAllText(path, jsonString);
            }
        }

        public TPresetItem FindPresetItemById(int id)
        {
            return PresetItems.FirstOrDefault(e => e.Id == id);
        }
    }
}
