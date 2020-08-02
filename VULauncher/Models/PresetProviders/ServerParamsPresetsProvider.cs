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
    }
}
