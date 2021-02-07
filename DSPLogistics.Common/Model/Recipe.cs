using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPLogistics.Common.Model
{
    public record Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; init; }

        public string Name { get; init; }

        public int TimeSpend { get; init; }

        public List<RecipeInput> Inputs { get; init; }

        public List<RecipeOutput> Outputs { get; init; }

        public string IconPath { get; init; }

        public int GridIndex { get; init; }

        public string Description { get; init; }

        public Recipe(int iD, string name, int timeSpend, List<RecipeInput> inputs, List<RecipeOutput> outputs, string iconPath, int gridIndex, string description)
        {
            ID = iD;
            Name = name;
            TimeSpend = timeSpend;
            Inputs = inputs;
            Outputs = outputs;
            IconPath = iconPath;
            GridIndex = gridIndex;
            Description = description;
        }

        public Recipe(int iD, string name, int timeSpend, string iconPath, int gridIndex, string description):
            this(iD, name, timeSpend, new List<RecipeInput>(), new List<RecipeOutput>(), iconPath, gridIndex, description)
        {

        }
    }
}
