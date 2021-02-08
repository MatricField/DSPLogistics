using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DSPLogistics.Common.Model
{
    [Index(nameof(ItemId))]
    public class RecipeInput
    {
        [Required]
        public int ID { get; init; }

        [Required]
        public int RecipeId { get; init; }

        [Required]
        public int ItemId { get; init; }

        [Required]
        public Item? Item { get; set; }

        [Required]
        public int Count { get; init; }

        public RecipeInput(int iD, int recipeId, int itemId, int count)
        {
            ID = iD;
            RecipeId = recipeId;
            ItemId = itemId;
            Count = count;
        }

        public RecipeInput(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }

}
