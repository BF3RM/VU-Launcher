using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
	public static class ParameterSelectionExtensions
	{
        public static ParameterSelectionItem ToItem(this ParameterSelection entity)
        {
            var item = new ParameterSelectionItem()
            {
                Id = entity.Id,
                ParameterString = entity.ParameterString,
                IsMandatory = entity.IsMandatory,
                Value = entity.Value,
                Description = entity.Description,
                ExpectedValue = entity.ExpectedValue,
                IsChecked = entity.IsChecked,
                IsDirty = false
            };

            return item;
        }

        public static ParameterSelection ToEntity(this ParameterSelectionItem item)
        {
            return new ParameterSelection()
            {
                Id = item.Id,
                ParameterString = item.ParameterString,
                IsMandatory = item.IsMandatory,
                Value = item.Value,
                Description = item.Description,
                ExpectedValue = item.ExpectedValue,
                IsChecked = item.IsChecked,
            };
        }

        public static List<ParameterSelectionItem> ToItemList(this IEnumerable<ParameterSelection> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<ParameterSelection> ToEntityList(this IEnumerable<ParameterSelectionItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
