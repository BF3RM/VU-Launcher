using System;
using System.Collections.Generic;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.Common;
using VULauncher.Models.Repositories.Static;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class ClientParamsPresetsProvider : PresetsProvider<ClientParamsPreset, ClientParamsPresetItem>
    {
        private static readonly Lazy<ClientParamsPresetsProvider> _lazy = new Lazy<ClientParamsPresetsProvider>(() => new ClientParamsPresetsProvider());
        public static ClientParamsPresetsProvider Instance => _lazy.Value;

        protected override string SubDirectory => "BanLists";
        public override List<ClientParamsPresetItem> PresetItems => PresetEntities.ToItemList();

        public ClientParamsPresetsProvider()
        {
            LoadDummyData();
        }

        private void LoadDummyData() // TODO: DUMMY
        {
            var clientParamsPreset = new ClientParamsPresetItem()
            {
                Name = "Client_Parameters",
            };

            var clientParameters = ParametersRepository.Instance.ClientParameters;

            var clientParameterItems = new List<ParameterSelectionItem>()
            {
                new ParameterSelectionItem()
                {
                    DisplayName = clientParameters[0].DisplayName,
                    AdditionalParameter = clientParameters[0].AdditionalParameter,
                    IsChecked = true,
                    IsDirty = false,
                },

                new ParameterSelectionItem()
                {
                    DisplayName = clientParameters[1].DisplayName,
                    AdditionalParameter = clientParameters[1].AdditionalParameter,
                    IsChecked = false,
                    IsDirty = false,
                },

                new ParameterSelectionItem()
                {
                    DisplayName = clientParameters[2].DisplayName,
                    AdditionalParameter = clientParameters[2].AdditionalParameter,
                    IsChecked = true,
                    IsDirty = false,
                },
            };

            clientParamsPreset.Parameters.AddRange(clientParameterItems);
            //clientParamsPreset.IsDirty = false; // treat it like user input

            PresetItems.Add(clientParamsPreset);
        }
    }
}
