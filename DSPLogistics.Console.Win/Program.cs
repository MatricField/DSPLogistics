using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPLogistics.Common.Win;
using DSPLogistics.Common.Resources;

namespace DSPLogistics.Console.Win
{
    class Program
    {
        static void Main(string[] args)
        {
            var finder = new GameLocationFinder();
            var db = GameDataBase.Load(finder.FindGame());
        }
    }
}
