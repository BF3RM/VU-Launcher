using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using VULauncher.Commands;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Common;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;
using VULauncher.ViewModels.Items.Extensions;
using VULauncher.Views.Common;
using VULauncher.Views.Dialogs;

namespace VULauncher.ViewModels.Common
{
    public delegate void TabIndexChangedEventHandler(object sender, TabIndexChangedEventArgs e);
    public delegate void PresetItemDeletedEventHandler(object sender, PresetItemDeletedEventArgs e);

    public abstract class PresetTabViewModel<TPresetItem, TPresetsProvider> : ItemsParentViewModel, IPresetTabViewModel
        where TPresetItem : PresetItem, new()
        where TPresetsProvider : IPresetsProvider<TPresetItem>
    {
        private TPresetItem _selectedPreset;

        protected virtual string NewPresetExampleName => "My_Preset";

        public ObservableItemCollection<TPresetItem> Presets { get; set; } = new ObservableItemCollection<TPresetItem>();
        public abstract string TabHeaderName { get; }

        public RelayCommand<ChangePresetTabParameters> ChangeTabCommand { get; }
        public RelayCommand CreatePresetCommand { get; }
        public RelayCommand DeletePresetCommand { get; }

        public bool HasPresetSelected => SelectedPreset != null;
        public bool CanCreatePreset => true;
        public bool CanDeletePreset => true;
        public bool CanChangeTab => true;

        protected TPresetsProvider PresetsProvider { get; }

        public event TabIndexChangedEventHandler TabIndexChanged;
        public event PresetItemDeletedEventHandler PresetItemDeleted;

        protected PresetTabViewModel(TPresetsProvider presetsProvider)
        {
	        CreatePresetCommand = new RelayCommand(x => CreatePreset(), x => CanCreatePreset);
	        DeletePresetCommand = new RelayCommand(x => DeletePreset(), x => CanDeletePreset);

	        ChangeTabCommand = new RelayCommand<ChangePresetTabParameters>(InvokeTabIndexChange, parameter => CanChangeTab);

	        PresetsProvider = presetsProvider;

	        LoadPresetItems(clearBeforeLoading: false, updateIsDirty: false);
	        RegisterChildItemCollection(Presets);
        }

        public void SetSelectedPreset(int selectedPresetId)
        {
            SelectedPreset = Presets.First(p => p.Id == selectedPresetId);
        }

        public void Save()
        {
            if (!IsDirty)
                return;

            PresetsProvider.Save(Presets.ToList());
        }

        public void ReloadItems()
        {
	        LoadPresetItems(clearBeforeLoading: true, updateIsDirty: true);
        }

        public void DiscardChanges()
        {
	        if (!IsDirty)
		        return;

            LoadPresetItems(clearBeforeLoading: true, updateIsDirty: true);
        }

        public virtual IEnumerable<ValidationError> GetValidationErrors()
        {
            return Presets.GetValidationErrors();
        }

        private void LoadPresetItems(bool clearBeforeLoading = true, bool updateIsDirty = true)
        {
	        if (clearBeforeLoading)
	        {
				Presets.Clear();
				SelectedPreset = null;
            }

            PresetsProvider.ReloadPresetItems();
	        Presets.AddRange(PresetsProvider.PresetItems);
	        Presets.IsDirty = false;
	        SelectedPreset = Presets.FirstOrDefault();
	        //IsDirty = false;

            if (updateIsDirty)
				NotifyPropertyChanged(nameof(IsDirty));
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

        private void InvokeTabIndexChange(ChangePresetTabParameters parameters)
        {
            TabIndexChanged?.Invoke(this, new TabIndexChangedEventArgs(parameters.TabIndex, parameters.SelectedPresetId));
        }

        private void CreatePreset()
        {
            var mainWindow = App.Current.MainWindow ?? throw new InvalidOperationException("App.Current.MainWindow cant be null");

            CreatePresetDialog dialog = new CreatePresetDialog(mainWindow, NewPresetExampleName);

            mainWindow.Effect = new BlurEffect();
            mainWindow.Opacity = 0.5;

            var result = dialog.ShowDialog();

            mainWindow.Opacity = 1;
            //mainWindow.Background = Brushes.White;
            mainWindow.Effect = null;

            if (result != true)
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

            var mainWindow = App.Current.MainWindow ?? throw new InvalidOperationException("App.Current.MainWindow cant be null");
            mainWindow.Effect = new BlurEffect();
            mainWindow.Opacity = 0.5;
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the preset '{SelectedPreset.Name}'?", "", MessageBoxButton.YesNo);
            mainWindow.Opacity = 1;
            mainWindow.Effect = null;

            if (result != MessageBoxResult.Yes)
                return;

            PresetItemDeleted?.Invoke(this, new PresetItemDeletedEventArgs(SelectedPreset.Id));
            Presets.Remove(SelectedPreset);
            SelectedPreset = Presets.FirstOrDefault();
        }
    }
}
