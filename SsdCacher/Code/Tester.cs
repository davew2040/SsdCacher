using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SsdCacher.Code.Logger;
using static SsdCacher.Code.FileCopier;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using SsdCacher.Code.ViewModels;

namespace SsdCacher.Code
{
    public class Tester
    {
        private const string SourceDirectory = @"H:\Games\SsdCacheTestSource";

        public void SetupTest()
        {
            GameEntry testEntry = CacherApp.AppViewModel.GameEntries.Where(entry => entry.Title == "Test").SingleOrDefault();

            if (Directory.Exists(testEntry.SourcePath))
            {
                Directory.Delete(testEntry.SourcePath, true);
            }

            string tempSourcePath = testEntry.SourcePath + FileManager.TempPathPostfix;

            if (Directory.Exists(tempSourcePath))
            {
                Directory.Delete(tempSourcePath, true);
            }

            string targetDirectory = CacherApp.AppViewModel.SsdPath + Path.DirectorySeparatorChar + testEntry.TargetDirectory;

            if (Directory.Exists(targetDirectory))
            {
                Directory.Delete(targetDirectory, true);
            }

            FileCopier.CopyAll(Tester.SourceDirectory, testEntry.SourcePath, new NullLogger());
        }
    }
}
