using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories
{
    public class ServerParamsPresetsRepository : FileRepository
    {
        private static readonly Lazy<ServerParamsPresetsRepository> _lazy = new Lazy<ServerParamsPresetsRepository>(() => new ServerParamsPresetsRepository());
        public static ServerParamsPresetsRepository Instance => _lazy.Value;

        public List<ServerParamsPresetItem> ServerParamsPresets = new List<ServerParamsPresetItem>();

        private ServerParamsPresetsRepository()
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
