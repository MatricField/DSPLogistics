using System;
using System.Collections.Generic;
using System.Text;

namespace DSPLogistics.Common.Model
{
    public record RecipeInput
    {
        public int ID { get; init; }

        public Item Item { get; init; }

        public int Count { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal RecipeInput()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public RecipeInput(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }

}
