using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using VULauncher.Extensions;

namespace VULauncher.ViewModels.Enums
{
    public static class EnumUtility
    {
        // Might want to return a named type, this is a lazy example (which does work though)
        public static object[] GetValuesAndNames(Type enumType)
        {
            var values = Enum.GetValues(enumType).Cast<object>();
            var valuesAndNames = from value in values
                select new
                {
                    Value = value,
                    Name = ((Enum) value).GetAttributeOfType<DisplayAttribute>().Name,
                };
            return valuesAndNames.ToArray();
        }
    }
}
