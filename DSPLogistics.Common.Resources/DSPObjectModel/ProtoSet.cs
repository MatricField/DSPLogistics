using System;
using System.Collections.Generic;
using System.Text;

namespace DSPLogistics.Common.Resources.DSPObjectModel
{
    public sealed class ProtoSet<T>
        where T: Proto
    {
        public string TableName { get; init; } = "";
        public IReadOnlyList<T> dataArray { get; init; } = Array.Empty<T>();
    }
}
