using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPLogistics.Common.Model
{
    public record RecipeOutput
    {
        public int ID { get; init; }

        public Item Item { get; init; }

        public int Count { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal RecipeOutput()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public RecipeOutput(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}
