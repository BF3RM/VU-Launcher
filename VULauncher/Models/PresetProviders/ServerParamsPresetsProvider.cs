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
    public class ServerParamsPresetsProvider : ParamsPresetsProvider<ServerParamsPreset, ServerParamsPresetItem>
    {
        private static readonly Lazy<ServerParamsPresetsProvider> _lazy = new Lazy<ServerParamsPresetsProvider>(() => new ServerParamsPresetsProvider());
        public static ServerParamsPresetsProvider Instance => _lazy.Value;

        protected override string FileName => "ServerParamsPresets";

        protected override List<LaunchParameter> Parameters => ParametersRepository.Instance.ServerParameters;

        protected override void LoadDummyData() // TODO: DUMMY
        {
            var serverParamsPreset = new ServerParamsPreset()
            {
                Id = 1,
                Name = "Server_Params",
            };

            //var serverParameters = ParametersRepository.Instance.ServerParameters;

            var serverParameterSelections = new List<ParameterSelection>()
            {
                new ParameterSelection()
                {
                    ParameterString = "highResTerrain",
                    IsChecked = true,
                },

                new ParameterSelection()
                {
                    ParameterString = "high120",
                    IsChecked = false,
                },

                new ParameterSelection()
                {
                    ParameterString = "updateBranch",
                    Value = "dev",
                    IsChecked = true,
                },
            };

            serverParamsPreset.ParameterSelections.AddRange(serverParameterSelections);

            PresetEntities.Add(serverParamsPreset);
        }
    }
}
