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
    public class ClientParamsPresetsProvider : PresetsProvider<ClientParamsPreset, ClientParamsPresetItem>
    {
        private static readonly Lazy<ClientParamsPresetsProvider> _lazy = new Lazy<ClientParamsPresetsProvider>(() => new ClientParamsPresetsProvider());
        public static ClientParamsPresetsProvider Instance => _lazy.Value;

        protected override string SubDirectory => "ClientParams";

        protected override IEnumerable<ClientParamsPreset> ConvertItemsToEntities(IEnumerable<ClientParamsPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<ClientParamsPresetItem> ConvertEntitiesToItems(IEnumerable<ClientParamsPreset> presetEntities)
        {
            var existingParameters = ParametersRepository.Instance.ClientParameters;
            var existingParameterStrings = existingParameters.Select(p => p.ParameterString);

            foreach (var presetEntity in presetEntities)
            {
                var notFoundParameterStrings = new List<string>();
                var notFoundParameterSelectionStrings = new List<string>();

                foreach (var parameterSelection in presetEntity.ParameterSelections)
                {
                    if (!existingParameterStrings.Any(param => param == parameterSelection.ParameterString))
                    {
                        notFoundParameterStrings.Add(parameterSelection.ParameterString);
                    }
                }

                var parameterSelectionNames = presetEntity.ParameterSelections.Select(m => m.ParameterString);

                foreach (var parameterString in existingParameterStrings)
                {
                    if (!parameterSelectionNames.Contains(parameterString))
                    {
                        notFoundParameterSelectionStrings.Add(parameterString);
                    }
                }

                // Add unchecked ParameterSelections for mods that have been added to the parametersRepository
                presetEntity.ParameterSelections.AddRange(notFoundParameterSelectionStrings.Select(n => new ParameterSelection() { IsChecked = false, ParameterString = n }));

                // Remove existing ParameterSelections for parameters that have been deleted from the parametersRepository
                presetEntity.ParameterSelections.RemoveAll(s => notFoundParameterStrings.Contains(s.ParameterString));

                presetEntity.ParameterSelections = presetEntity.ParameterSelections.OrderBy(s => s.ParameterString).ToList();

                foreach (var parameterSelection in presetEntity.ParameterSelections)
                {
                    var parameter = existingParameters.First(p => p.ParameterString == parameterSelection.ParameterString);

                    parameterSelection.IsMandatory = parameter.IsMandatory;
                    parameterSelection.ExpectedValue = parameter.ExpectedValue;
                    parameterSelection.Description = parameter.Description;

                    if (parameterSelection.IsMandatory)
                        parameterSelection.IsChecked = true;
                }
            }

            return presetEntities.ToItemList();
        }

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
