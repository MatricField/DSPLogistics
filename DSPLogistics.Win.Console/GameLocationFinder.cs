using Microsoft.Win32;
using System.IO;

namespace DSPLogistics.Win
{
    public class GameLocationFinder
    {
        private const string DSPGameConfigRegKey = @"HKEY_CURRENT_USER\System\GameConfigStore\Children\0758a38d-d535-4e2b-895a-d174d0ba3158";
        private const string DSPGameConfigRegValName = "MatchedExeFullPath";
        public string? TryFindGame()
        {
            return TryFindGameImpl();
        }

        protected virtual string? TryFindGameImpl()
        {
            var obj = Registry.GetValue(DSPGameConfigRegKey, DSPGameConfigRegValName, null);
            var path = obj as string;
            return Path.GetDirectoryName(path);
        }
    }
}
