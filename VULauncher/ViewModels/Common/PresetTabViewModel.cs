using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.Commands;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;
using VULauncher.Views.Dialogs;

namespace VULauncher.ViewModels.Common
{
    public interface ITabViewModel
    {
        event TabIndexChangedEventHandler TabIndexChanged;
    }

    public delegate void TabIndexChangedEventHandler(object sender, TabIndexChangedEventArgs e);

    public abstract class PresetTabViewModel<T> : ItemsParentViewModel, ITabViewModel
        where T : IPresetItem, new()
    {
        private T _selectedPreset;

        public PresetCollection<T> Presets { get; set; } = new PresetCollection<T>();
        public abstract string TabHeaderName { get; }

        public RelayCommand ChangeTabCommand { get; }
        public RelayCommand CreatePresetCommand { get; }
        public RelayCommand DeletePresetCommand { get; }

        public bool HasPresetSelected => SelectedPreset != null;
        public bool CanCreatePreset => true;
        public bool CanDeletePreset => true;
        public bool CanChangeTab => true;

        public event TabIndexChangedEventHandler TabIndexChanged;

        protected PresetTabViewModel()
        {
            CreatePresetCommand = new RelayCommand(x => CreatePreset(), x => CanCreatePreset);
            DeletePresetCommand = new RelayCommand(x => DeletePreset(), x => CanDeletePreset);

            ChangeTabCommand = new RelayCommand(parameter => InvokeTabIndexChange(int.Parse((string)parameter)), parameter => CanChangeTab);

            RegisterChildItemCollection(Presets);
        }

        public T SelectedPreset
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
            CreatePresetDialog dialog = new CreatePresetDialog();

            if (dialog.ShowDialog() != true)
                return;

            var presetName = dialog.PresetNameTextBoxText;

            if (string.IsNullOrWhiteSpace(presetName))
                throw new InvalidOperationException("String cant be null or whitespace");

            var preset = new T()
            {
                Name = presetName,
            };

            Presets.Add(preset);
            preset.Name = presetName;
            SelectedPreset = preset;
        }

        private void DeletePreset()
        {
            if (SelectedPreset == null)
                return;

            Presets.Remove(SelectedPreset);
            SelectedPreset = Presets.FirstOrDefault();
        }
    }

    public class TabIndexChangedEventArgs : EventArgs
    {
        public TabIndexChangedEventArgs(int newTabIndex)
        {
            NewTabIndex = newTabIndex;
        }

        public int NewTabIndex { get; set; }
    }
}
