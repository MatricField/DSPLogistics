using DSPLogistics.Common;
using DSPLogistics.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPLogistics.Win.ConsoleApp
{
    public class Planner
    {
        private DSPLogisticsDbContext dspDB;
        public ISet<int> InputItemIds { get; } = new HashSet<int>();

        public ISet<int> OutputItemIds { get; } = new HashSet<int>();

        public Planner(DSPLogisticsDbContext db)
        {
            dspDB = db;
        }


    }
}
