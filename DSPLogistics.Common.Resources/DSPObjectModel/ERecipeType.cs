using System;
using System.Collections.Generic;
using System.Text;

namespace DSPLogistics.Common.Resources.DSPObjectModel
{
	public enum ERecipeType
	{
		None = 0,
		Smelt = 1,
		Chemical = 2,
		Refine = 3,
		Assemble = 4,
		Particle = 5,
		Exchange = 6,
		PhotonStore = 7,
		Fractionate = 8,
		Research = 0xF
	}

}
