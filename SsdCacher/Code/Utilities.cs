using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SsdCacher.Code.ViewModels;

namespace SsdCacher.Code
{
    public class Utilities
    {
        public static string GetFullSsdPath(GameEntry game)
        {
            return CacherApp.AppViewModel.SsdPath + Path.DirectorySeparatorChar + game.TargetDirectory;
        }

        public static bool DetermineIsCached(GameEntry game)
        {
            string ssdFullPath = Utilities.GetFullSsdPath(game);

            return Directory.Exists(ssdFullPath);
        }
    }
}
