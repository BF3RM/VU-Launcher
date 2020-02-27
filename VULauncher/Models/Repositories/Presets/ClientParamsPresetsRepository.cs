using System;
using System.Collections.Generic;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories
{
    public class ClientParamsPresetsRepository : FileRepository
    {
        private static readonly Lazy<ClientParamsPresetsRepository> _lazy = new Lazy<ClientParamsPresetsRepository>(() => new ClientParamsPresetsRepository());
        public static ClientParamsPresetsRepository Instance => _lazy.Value;

        public List<ClientParamsPresetItem> ClientParamsPresets = new List<ClientParamsPresetItem>();

        private ClientParamsPresetsRepository()
        {
            base.Initialize();
        }

        public override void Load() // TODO: DUMMY
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
            clientParamsPreset.IsDirty = false;

            ClientParamsPresets.Add(clientParamsPreset);
        }
    }
}
