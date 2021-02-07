using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DSPLogistics.Common.Model
{
    public record Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; init; }

        public string Name { get; init; }

        public string IconPath { get; init; }

        public int GridIndex { get; init; }

        public string Description { get; init; }

        public Item(int iD, string name, string iconPath, int gridIndex, string description)
        {
            ID = iD;
            Name = name;
            IconPath = iconPath;
            GridIndex = gridIndex;
            Description = description;
        }
    }
}
