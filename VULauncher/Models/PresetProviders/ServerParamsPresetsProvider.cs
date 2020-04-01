using System;
using System.Collections.Generic;
using VULauncher.Models.Repositories.Common;
using VULauncher.Models.Repositories.Static;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class ServerParamsPresetsProvider : FileRepository
    {
        private static readonly Lazy<ServerParamsPresetsProvider> _lazy = new Lazy<ServerParamsPresetsProvider>(() => new ServerParamsPresetsProvider());
        public static ServerParamsPresetsProvider Instance => _lazy.Value;

        public List<ServerParamsPresetItem> ServerParamsPresets = new List<ServerParamsPresetItem>();

        private ServerParamsPresetsProvider()
        {
            base.Initialize();
        }

        public override void Load() // TODO: DUMMY
        {
            var serverParamsPreset = new ServerParamsPresetItem()
            {
                Name = "Server_Params",
            };

            var serverParameters = ParametersRepository.Instance.ServerParameters;

            var serverParameterItems = new List<ParameterSelectionItem>()
            {
                new ParameterSelectionItem()
                {
                    DisplayName = serverParameters[0].DisplayName,
                    AdditionalParameter = serverParameters[0].AdditionalParameter,
                    IsChecked = true,
                    IsDirty = false,
                },

                new ParameterSelectionItem()
                {
                    DisplayName = serverParameters[1].DisplayName,
                    AdditionalParameter = serverParameters[1].AdditionalParameter,
                    IsChecked = false,
                    IsDirty = false,
                },

                new ParameterSelectionItem()
                {
                    DisplayName = serverParameters[2].DisplayName,
                    AdditionalParameter = serverParameters[2].AdditionalParameter,
                    IsChecked = true,
                    IsDirty = false,
                },
            };

            serverParamsPreset.Parameters.AddRange(serverParameterItems);
            serverParamsPreset.IsDirty = false;

            ServerParamsPresets.Add(serverParamsPreset);
        }
    }
}
