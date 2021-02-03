using System;
using System.Collections.Generic;
using System.Text;

namespace DSPLogistics.Common.Resources.DSPObjectModel
{
    public class RecipeProto : Proto
    {
		public ERecipeType Type { get; set; }

		public bool Handcraft { get; set; }

		public bool Explicit { get; set; }

		public int TimeSpend { get; set; }

		public int[] Items { get; set; }

		public int[] ItemCounts { get; set; }

		public int[] Results { get; set; }

		public int[] ResultCounts { get; set; }

		public int GridIndex { get; set; }

		public string IconPath { get; set; }

		public string Description { get; set; }
	}
}
