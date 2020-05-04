using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.Common;
using VULauncher.Models.Repositories.Static;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class ClientParamsPresetsProvider : ParamsPresetsProvider<ClientParamsPreset, ClientParamsPresetItem>
    {
        private static readonly Lazy<ClientParamsPresetsProvider> _lazy = new Lazy<ClientParamsPresetsProvider>(() => new ClientParamsPresetsProvider());
        public static ClientParamsPresetsProvider Instance => _lazy.Value;

        protected override string FileName => "ClientParams";

        protected override List<LaunchParameter> Parameters => ParametersRepository.Instance.ClientParameters;

        protected override void LoadDummyData() // TODO: DUMMY
        {
            var clientParamsPreset = new ClientParamsPreset()
            {
                Id = 1,
                Name = "Client_Parameters",
            };

            //var clientParameters = ParametersRepository.Instance.ClientParameters;

            var clientParameters = new List<ParameterSelection>()
            {
                new ParameterSelection()
                {
                    ParameterString = "updateBranch",
                    Value = "dev",
                    IsChecked = true,
                },

                new ParameterSelection()
                {
                    ParameterString = "perftrace",
                    IsChecked = false,
                },

                new ParameterSelection()
                {
                    ParameterString = "console",
                    IsChecked = true,
                },
            };

            clientParamsPreset.ParameterSelections.AddRange(clientParameters);

            PresetEntities.Add(clientParamsPreset);
        }
    }
}
