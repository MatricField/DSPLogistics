using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace DSPLogistics.Common.Win
{
    public class GameLocationFinder
    {
        private const string DSPGameConfigRegKey = @"HKEY_CURRENT_USER\System\GameConfigStore\Children\0758a38d-d535-4e2b-895a-d174d0ba3158";
        private const string DSPGameConfigRegValName = "MatchedExeFullPath";
        public string FindGame()
        {
            return FindGameImpl();
        }

        protected virtual string FindGameImpl()
        {
            var obj = Registry.GetValue(DSPGameConfigRegKey, DSPGameConfigRegValName, null);
            var path = obj as string;
            return Path.GetDirectoryName(path);
        }
    }
}
