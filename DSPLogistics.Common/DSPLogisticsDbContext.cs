using DSPLogistics.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace DSPLogistics.Common
{
    public class DSPLogisticsDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeInput> RecipeInputs { get; set; }

        public DbSet<RecipeOutput> RecipeOutputs { get; set; }

        public DbSet<LocalizedString> LocalizedStrings { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
