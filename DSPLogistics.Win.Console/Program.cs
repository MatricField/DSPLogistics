using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPLogistics.Common;
using DSPLogistics.Common.Resources;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DSPLogistics.Win.ConsoleApp
{
    class Program
    {
        static readonly string DBPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DSPLogistics", "DSPLogisticsDb.sqlite");

        static void Main(string[] args)
        {
            DSPLogisticsDbContext dSPLogisticsDb;
            if(File.Exists(DBPath))
            {
                var connectionString = new SqliteConnectionStringBuilder()
                {
                    Mode = SqliteOpenMode.ReadOnly,
                    DataSource = DBPath
                }.ToString();
                dSPLogisticsDb = new DSPLogisticsDbContext(connectionString);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(DBPath) ?? throw new Exception());
                var connectionString = new SqliteConnectionStringBuilder()
                {
                    Mode = SqliteOpenMode.ReadWriteCreate,
                    DataSource = DBPath
                }.ToString();
                dSPLogisticsDb = new DSPLogisticsDbContext(connectionString);
                LoadGameData(dSPLogisticsDb);
            }
            using(dSPLogisticsDb)
            {

                dSPLogisticsDb.Database.EnsureDeleted();
            }
        }

        static void LoadGameData(DSPLogisticsDbContext dspLogisticsDb)
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
                    gameDb.SaveTo(dspLogisticsDb);
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
