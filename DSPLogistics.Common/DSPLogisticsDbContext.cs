using DSPLogistics.Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPLogistics.Common
{
    public class DSPLogisticsDbContext : DbContext
    {
        private DbSet<Item>? items;
        private DbSet<Recipe>? recipes;
        private DbSet<RecipeInput>? recipeInputs;
        private DbSet<RecipeOutput>? recipeOutputs;

        public DbSet<Item> Items { get => items ?? throw new InvalidOperationException(); set => items = value; }

        public DbSet<Recipe> Recipes { get => recipes ?? throw new InvalidOperationException(); set => recipes = value; }

        public DbSet<RecipeInput> RecipeInputs { get => recipeInputs ?? throw new InvalidOperationException(); set => recipeInputs = value; }

        public DbSet<RecipeOutput> RecipeOutputs { get => recipeOutputs ?? throw new InvalidOperationException(); set => recipeOutputs = value; }

        public DSPLogisticsDbContext() :
            base()
        {
            Database.EnsureCreated();
        }

        public DSPLogisticsDbContext(string connectionString):
            base(
                new DbContextOptionsBuilder<DSPLogisticsDbContext>()
                .UseSqlite(connectionString)
                .Options
                )
        {
            Database.EnsureCreated();
        }

        public DSPLogisticsDbContext(DbContextOptions options) :
            base(options)
        {
            Database.EnsureCreated();
        }
    }
}
