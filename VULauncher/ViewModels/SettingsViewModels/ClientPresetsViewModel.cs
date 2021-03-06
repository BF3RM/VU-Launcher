﻿using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ClientPresetsViewModel : PresetTabViewModel<ClientPresetItem, ClientPresetsProvider>
    {
        public override string TabHeaderName => "Client Presets";
        protected override string NewPresetExampleName => "My_Client_Preset";

        public ClientParamsViewModel ClientParamsViewModel { get; set; }

        public ClientPresetsViewModel(ClientParamsViewModel clientParamsViewModel)
            : base(ClientPresetsProvider.Instance)
        {
            ClientParamsViewModel = clientParamsViewModel;
            ClientParamsViewModel.PresetItemDeleted += ClientParamsViewModel_PresetItemDeleted;
        }

        private void ClientParamsViewModel_PresetItemDeleted(object sender, PresetItemDeletedEventArgs e)
        {
            foreach (var clientPresetItem in Presets)
            {
                if (clientPresetItem.ClientParamsPreset.Id == e.DeletedPresetId)
                    clientPresetItem.ClientParamsPreset = null;
            }
        }
    }
}
