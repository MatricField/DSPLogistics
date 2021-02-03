using System;
using System.Collections.Generic;
using System.Text;

namespace DSPLogistics.Common.Resources.DSPObjectModel
{
    public sealed class ProtoSet<T>
        where T: Proto
    {
        public string TableName { get; set; }
        public IReadOnlyList<T> dataArray { get; set; }
    }
}
