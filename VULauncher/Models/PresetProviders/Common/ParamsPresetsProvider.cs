using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Common;
using VULauncher.Models.Entities.Extensions;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.Models.PresetProviders.Common
{
	public abstract class ParamsPresetsProvider<TPresetEntity, TPresetItem> : PresetsProvider<TPresetEntity, TPresetItem>
		where TPresetEntity : ParamsPresetEntity, new()
		where TPresetItem : ParamsPresetItem, new()
	{
		protected abstract List<LaunchParameter> Parameters { get; }

        protected override IEnumerable<TPresetEntity> ConvertItemsToEntities(IEnumerable<TPresetItem> presetItems)
        {
            return presetItems.ToEntityList<TPresetEntity, TPresetItem>();
        }

        protected override IEnumerable<TPresetItem> ConvertEntitiesToItems(IEnumerable<TPresetEntity> presetEntities)
        {
            var existingParameters = Parameters;
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

                //presetEntity.ParameterSelections = presetEntity.ParameterSelections.OrderBy(s => s.ParameterString).ToList();
                presetEntity.ParameterSelections = CompleteParameterSelectionContent(presetEntity.ParameterSelections);
            }

            return presetEntities.ToItemList<TPresetEntity, TPresetItem>();
        }

        protected override TPresetItem CreateNewPresetItem(TPresetItem newPresetItem)
        {
            var parameterSelections = Parameters.Select(n => new ParameterSelection() { IsChecked = false, ParameterString = n.ParameterString }).ToList();
            newPresetItem.ParameterSelections.AddRange(CompleteParameterSelectionContent(parameterSelections).ToItemList());
            return newPresetItem;
        }

        private List<ParameterSelection> CompleteParameterSelectionContent(IEnumerable<ParameterSelection> parameterSelections)
        {
            foreach (var parameterSelection in parameterSelections)
            {
                var parameter = Parameters.First(p => p.ParameterString == parameterSelection.ParameterString);

                parameterSelection.IsMandatory = parameter.IsMandatory;
                parameterSelection.ExpectedValue = parameter.ExpectedValue;
                parameterSelection.Description = parameter.Description;

                if (parameterSelection.IsMandatory)
                    parameterSelection.IsChecked = true;
            }

            return parameterSelections.OrderBy(s => s.ParameterString).ToList();
        }
    }
}
