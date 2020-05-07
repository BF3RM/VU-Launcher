using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VULauncher.ViewModels.Items.Extensions
{
    public static class SelectedParametersConcatExtensions
    {
        public static string ConcatStartupStrings(this IEnumerable<ParameterSelectionItem> parameterSelectionItems)
        {
            var concatenatedString = "";

            foreach (var parameterSelectionItem in parameterSelectionItems)
            {
                concatenatedString += "-" + (string.IsNullOrWhiteSpace(parameterSelectionItem.Value)
                                              ? parameterSelectionItem.ParameterString
                                              : parameterSelectionItem.ParameterString + " " +  parameterSelectionItem.Value)
                                          + " ";
            }

            return concatenatedString;
        }
    }
}
