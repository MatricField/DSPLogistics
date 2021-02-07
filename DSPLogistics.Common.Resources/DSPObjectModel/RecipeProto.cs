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

		public int[] Items { get; set; } = Array.Empty<int>();

		public int[] ItemCounts { get; set; } = Array.Empty<int>();

		public int[] Results { get; set; } = Array.Empty<int>();

		public int[] ResultCounts { get; set; } = Array.Empty<int>();

		/// <remarks>
		/// Grid Index : X X X X
		///              ^ ^ ^ ^
		///              | | | |
		///              | | Horizontal index on page (2 digits)
		///              | Vertical index on page
		///              Page index
		/// All indeces are 1-based
		/// </remarks>
		public int GridIndex { get; set; }

		public string IconPath { get; set; } = "";

		public string Description { get; set; } = "";
	}
}
