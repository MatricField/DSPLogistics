using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSPLogistics.Common.Model
{
    public class Recipe
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; init; }

        [Required]
        public string NameID { get; init; }

        public LocalizedString? Name { get; set; }

        [Required]
        public int TimeSpend { get; init; }

        public IList<RecipeInput> Inputs { get; init; }

        public IList<RecipeOutput> Outputs { get; init; }

        public Recipe(int iD, LocalizedString name, int timeSpend, IList<RecipeInput> inputs, IList<RecipeOutput> outputs)
        {
            ID = iD;
            NameID = name.Name;
            Name = name;
            TimeSpend = timeSpend;
            Inputs = inputs;
            Outputs = outputs;
        }

        public Recipe(int iD, string nameID, int timeSpend)
        {
            ID = iD;
            NameID = nameID;
            TimeSpend = timeSpend;
            Inputs = new List<RecipeInput>();
            Outputs = new List<RecipeOutput>();
        }
    }
}
