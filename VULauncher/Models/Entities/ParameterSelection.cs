using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
	public class ParameterSelection : SelectionEntity
	{
		public string ParameterString { get; set; }
		public string Value { get; set; }
		[JsonIgnore]
		public bool IsMandatory { get; set; }
		[JsonIgnore]
		public string ExpectedValue { get; set; }
		[JsonIgnore]
		public string Description { get; set; }
	}
}
