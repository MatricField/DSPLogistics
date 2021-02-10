using DSPLogistics.Common;
using DSPLogistics.Common.Resources;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace DSPLogistics.Win.ConsoleApp
{
    class Program
    {
        static readonly string AppDataPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DSPLogistics");
        static readonly string DBPath =
            Path.Combine(AppDataPath, "DSPLogisticsDb.sqlite");

        static async Task Main(string[] args)
        {

            using(var dSPLogisticsDb = await LoadGameDatabase())
            {
                var items = dSPLogisticsDb
                    .Items
                    .Include(x => x.Name)
                    .Include(x => x.Description);

                var recipe = dSPLogisticsDb
                    .Recipes
                    .Include(x => x.Name)
                    .Include(x => x.Inputs)
                    .Include(x => x.Outputs);
            }
        }

        static async Task<DSPLogisticsDbContext> LoadGameDatabase()
        {
            DSPLogisticsDbContext dSPLogisticsDb;
            if (File.Exists(DBPath))
            {
                var connectionString = new SqliteConnectionStringBuilder()
                {
                    Mode = SqliteOpenMode.ReadOnly,
                    DataSource = DBPath
                }.ToString();
                dSPLogisticsDb = new DSPLogisticsDbContext(connectionString);
                // TODO: handle migration later
            }
            else
            {
                Directory.CreateDirectory(AppDataPath);
                var connectionString = new SqliteConnectionStringBuilder()
                {
                    Mode = SqliteOpenMode.ReadWriteCreate,
                    DataSource = DBPath
                }.ToString();
                dSPLogisticsDb = new DSPLogisticsDbContext(connectionString);
                await dSPLogisticsDb.Database.EnsureCreatedAsync();
                await LoadGameData(dSPLogisticsDb);
            }
            return dSPLogisticsDb;
        }

        static async Task LoadGameData(DSPLogisticsDbContext dspLogisticsDb)
        {
            try
            {
                var finder = new GameLocationFinder();
                var gameLocation = finder.TryFindGame();
                if (gameLocation is null)
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    var gameDb = GameDataBase.Load(gameLocation);
                    await gameDb.SaveTo(dspLogisticsDb);
                }
            }
            catch(Exception)
            {
                dspLogisticsDb.Database.EnsureDeleted();
                throw;
            }
        }
    }
}
