using DSPLogistics.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace DSPLogistics.Common
{
    public class DSPLogisticsDbContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();

        public DbSet<Recipe> Recipes => Set<Recipe>();

        public DbSet<RecipeInput> RecipeInputs => Set<RecipeInput>();

        public DbSet<RecipeOutput> RecipeOutputs => Set<RecipeOutput>();

        public DbSet<LocalizedString> LocalizedStrings => Set<LocalizedString>();

        public DSPLogisticsDbContext() :
            base()
        {

        }

        public DSPLogisticsDbContext(string connectionString):
            this(
                new DbContextOptionsBuilder<DSPLogisticsDbContext>()
                .UseSqlite(connectionString)
                .Options
                )
        {

        }

        public DSPLogisticsDbContext(DbContextOptions options) :
            base(options)
        {

        }
    }
}
