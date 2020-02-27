using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VULauncher.ViewModels.Enums
{
    public enum FrequencyType
    {
        [Display(Name = "30Hz")]
        _30Hz,
        [Display(Name = "60Hz")]
        _60Hz,
        [Display(Name = "120Hz")]
        _120Hz,
    }
}
