using System;
using System.Collections.Generic;
using System.Text;

namespace DSPLogistics.Common.Resources.DSPObjectModel
{
    public sealed class ItemProto : Proto
    {
		public EItemType Type { get; set; }

		public string MiningFrom { get; set; }

		public string ProduceFrom { get; set; }

		public int StackSize { get; set; }

		public bool IsFluid { get; set; }

		public bool IsEntity { get; set; }

		public bool CanBuild { get; set; }

		public bool BuildInGas { get; set; }

		public string IconPath { get; set; }

		public int ModelIndex { get; set; }

		public int ModelCount { get; set; }

		public int HpMax { get; set; }

		public int Ability { get; set; }

		public long HeatValue { get; set; }

		public long Potential { get; set; }

		public float ReactorInc { get; set; }

		public int FuelType { get; set; }

		public int BuildIndex { get; set; }

		public int BuildMode { get; set; }

		public int GridIndex { get; set; }

		public int UnlockKey { get; set; }

		public int PreTechOverride { get; set; }

		public int[] DescFields { get; set; }

		public string Description { get; set; }
	}
}
