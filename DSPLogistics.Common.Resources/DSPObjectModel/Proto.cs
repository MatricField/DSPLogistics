using System;
using System.Collections.Generic;
using System.Text;

namespace DSPLogistics.Common.Resources.DSPObjectModel
{
    public abstract class Proto
    {
        public string Name { get; set; } = "";

        public int ID { get; set; }

        public string SID { get; set; } = "";
    }
}
