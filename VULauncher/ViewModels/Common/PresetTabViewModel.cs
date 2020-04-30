using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using VULauncher.Commands;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Common;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;
using VULauncher.Views.Dialogs;

namespace VULauncher.ViewModels.Common
{
    public delegate void TabIndexChangedEventHandler(object sender, TabIndexChangedEventArgs e);

    public abstract class PresetTabViewModel<TPresetItem, TPresetsProvider> : ItemsParentViewModel, IPresetTabViewModel
        where TPresetItem : PresetItem, new()
        where TPresetsProvider : IPresetsProvider<TPresetItem>
    {
        private TPresetItem _selectedPreset;

        protected virtual string NewPresetExampleName => "My_Preset";

        public ObservableItemCollection<TPresetItem> Presets { get; set; } = new ObservableItemCollection<TPresetItem>();
        public abstract string TabHeaderName { get; }

        public RelayCommand ChangeTabCommand { get; }
        public RelayCommand CreatePresetCommand { get; }
        public RelayCommand DeletePresetCommand { get; }

        public bool HasPresetSelected => SelectedPreset != null;
        public bool CanCreatePreset => true;
        public bool CanDeletePreset => true;
        public bool CanChangeTab => true;

        protected TPresetsProvider PresetsProvider { get; }

        public event TabIndexChangedEventHandler TabIndexChanged;

        public void Save()
        {
            if (!IsDirty)
                return;

            PresetsProvider.Save(Presets.Where(p => p.IsDirty));
        }

        protected PresetTabViewModel(TPresetsProvider presetsProvider)
        {
            CreatePresetCommand = new RelayCommand(x => CreatePreset(), x => CanCreatePreset);
            DeletePresetCommand = new RelayCommand(x => DeletePreset(), x => CanDeletePreset);

            ChangeTabCommand = new RelayCommand(parameter => InvokeTabIndexChange(int.Parse((string)parameter)), parameter => CanChangeTab);

            PresetsProvider = presetsProvider;

            Presets.AddRange(PresetsProvider.PresetItems);
            SelectedPreset = Presets.FirstOrDefault();

            RegisterChildItemCollection(Presets);
        }

        public TPresetItem SelectedPreset
        {
            get => _selectedPreset;
            set
            {
                if (SetField(ref _selectedPreset, value))
                {
                    NotifyPropertyChanged(nameof(HasPresetSelected));
                }
            }
        }

        private void InvokeTabIndexChange(int newTabIndex)
        {
            TabIndexChanged?.Invoke(this, new TabIndexChangedEventArgs(newTabIndex));
        }

        private void CreatePreset()
        {
            CreatePresetDialog dialog = new CreatePresetDialog(NewPresetExampleName);

            if (dialog.ShowDialog() != true)
                return;

            var presetName = dialog.PresetNameTextBoxText;

            if (string.IsNullOrWhiteSpace(presetName))
                throw new InvalidOperationException("String cant be null or whitespace");

            var preset = PresetsProvider.CreateEmptyPresetItem(presetName);

            Presets.Add(preset);
            preset.Name = presetName;
            SelectedPreset = preset;
        }

        private void DeletePreset()
        {
            if (SelectedPreset == null)
                return;

            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the preset '{SelectedPreset.Name}'?", "", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
                return;

            Presets.Remove(SelectedPreset);
            SelectedPreset = Presets.FirstOrDefault();
        }
    }
}
