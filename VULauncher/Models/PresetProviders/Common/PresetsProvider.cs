﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VULauncher.Models.Config;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.Models.PresetProviders.Common
{
    public abstract class PresetsProvider<TPresetEntity, TPresetItem> : IPresetsProvider<TPresetItem>
        where TPresetEntity : PresetEntity
        where TPresetItem : PresetItem, new()
    {
        protected List<TPresetEntity> PresetEntities { get; set; } = new List<TPresetEntity>();
        public List<TPresetItem> PresetItems { get; set; } = new List<TPresetItem>();
        protected string PersistenceDirectory => Path.Combine(Configuration.UserDataDirectory, "_UserData");
        private string SaveFilePath => Path.Combine(PersistenceDirectory, $"{FileName}.json");

        protected abstract string FileName { get; }
        protected abstract IEnumerable<TPresetEntity> ConvertItemsToEntities(IEnumerable<TPresetItem> presetItems);
        protected abstract IEnumerable<TPresetItem> ConvertEntitiesToItems(IEnumerable<TPresetEntity> presetEntities);

        protected PresetsProvider()
        {
            //LoadDummyData();
            Load(resetPresetLists: false);
        }

        protected abstract void LoadDummyData(); // Can either add dummy Presets as Entities or Items to the according Lists

        private void Load(bool resetPresetLists = true)
        {
            if (resetPresetLists)
            {
                PresetEntities.Clear();
                PresetItems.Clear();
            }

            PresetEntities.AddRange(GetEntitiesFromFiles());
            PresetItems.AddRange(ConvertEntitiesToItems(PresetEntities));
        }

        private IEnumerable<TPresetEntity> GetEntitiesFromFiles()
        {
            if (!Directory.Exists(PersistenceDirectory))
                Directory.CreateDirectory(PersistenceDirectory);

            if (!File.Exists(SaveFilePath))
                return Enumerable.Empty<TPresetEntity>();

            var entities = JsonConvert.DeserializeObject<IEnumerable<TPresetEntity>>(File.ReadAllText(SaveFilePath));

            return entities;
        }

        //public IEnumerable<TPresetItem> LoadPresetItems()
        //{
        // return ConvertEntitiesToItems(PresetEntities);
        //}

        public void ReloadPresetItems()
        {
            Load(resetPresetLists: true);
        }

        public void Save(IEnumerable<TPresetItem> presetItems)
        {
            var entities = ConvertItemsToEntities(presetItems);
            SaveEntities(entities);
        }

        private void SaveEntities(IEnumerable<TPresetEntity> presetEntities)
        {
            var jsonString = JsonConvert.SerializeObject(presetEntities);
            File.WriteAllText(SaveFilePath, jsonString);
            Load(resetPresetLists: true);
        }

        public TPresetItem FindPresetItemById(int id)
        {
            return PresetItems.FirstOrDefault(e => e.Id == id);
        }

        public TPresetItem CreateEmptyPresetItem(string presetName)
        {
            var newPresetItem = new TPresetItem { Id = GetNewPresetId(), Name = presetName };
            return CreateEmptyPresetItem(newPresetItem);
        }

        protected virtual TPresetItem CreateEmptyPresetItem(TPresetItem newPresetItem)
        {
            return newPresetItem;
        }

        private int GetNewPresetId()
        {
            return (PresetItems.Any() ? PresetItems.Max(p => p.Id) : 0) + 1;
        }
    }
}
