using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using SsdCacher.Code.Save;
using SsdCacher.Code.ViewModels;
using static SsdCacher.Code.FileCopier;

namespace SsdCacher.Code
{
    public class CacherApp
    {
        private const string ConfigFileName = "config.cfg";

        static CacherApp()
        {
            CacherApp.AppState = new AppState();

            InitializeAppData();
        }

        public static AppState AppState { get; private set; }

        private static AppViewModel appViewModel = null;
        public static AppViewModel AppViewModel
        {
            get
            {
                if (CacherApp.appViewModel == null)
                {
                    CacherApp.appViewModel = new AppViewModel();
                }

                return CacherApp.appViewModel;
            }
            private set { }
        }

        public static void CacheGame(GameEntry entry)
        {
            Task cacheTask = Task.Factory.StartNew(() => BackgroundCacheGame(entry)).ContinueWith((task) => CacheComplete(entry));
        }

        private static string BackgroundCacheGame(GameEntry entry)
        {
            CacherApp.AppState.ActiveFileCopyInfo = FileCopier.CountFiles(entry.SourcePath);

            try
            {
                FileManager.CacheGame(entry, CacherApp.AppViewModel.SsdPath, CacherApp.AppState.AppLogger, CacherApp.FileCopyStatusUpdater);
            }
            catch(FileManager.FileManagerException e)
            {
                CacherApp.AppViewModel.StatusText = "ERROR: " + e.Message;
            }

            return null;
        }

        private static void CacheComplete(GameEntry entry)
        {
            entry.IsCached = true;
        }


        public static void UncacheGame(GameEntry entry)
        {
            Task cacheTask = Task.Factory.StartNew(() => BackgroundUncacheGame(entry)).ContinueWith((task) => UncacheComplete(entry));
        }

        private static string BackgroundUncacheGame(GameEntry entry)
        {
            string ssdPath = CacherApp.AppViewModel.SsdPath + Path.DirectorySeparatorChar + entry.TargetDirectory;
            CacherApp.AppState.ActiveFileCopyInfo = FileCopier.CountFiles(ssdPath);

            try
            {
                FileManager.UncacheGame(entry, CacherApp.AppViewModel.SsdPath, CacherApp.AppState.AppLogger, CacherApp.FileCopyStatusUpdater);
            }
            catch (FileManager.FileManagerException e)
            {
                CacherApp.AppViewModel.StatusText = "ERROR: " + e.Message;
            }

            return null;
        }

        private static void UncacheComplete(GameEntry entry)
        {
            entry.IsCached = false;
        }

        private static void FileCopyStatusUpdater(FileCopyProgress progress)
        {
            CacherApp.AppViewModel.StatusText = string.Format("Copied {0}/{1} files, {2}/{3} total data.",
                progress.FilesCount,
                CacherApp.AppState.ActiveFileCopyInfo.FilesCount,
                CacherApp.FormatFileSize(progress.FileSizeCopied),
                CacherApp.FormatFileSize(CacherApp.AppState.ActiveFileCopyInfo.FileSizeSum));
        }

        private static string FormatFileSize(long bytes)
        {
            if (bytes < 1000)
            {
                return bytes.ToString() + "B";
            }
            else if (bytes < 1000000)
            {
                double kb = bytes / 1000.0;
                return String.Format("{0:0.00}", kb) + "KB";
            }
            else if (bytes < 1000000000)
            {
                double mb = bytes / 1000000.0;
                return String.Format("{0:0.00}", mb) + "MB";
            }
            else 
            {
                double gb = bytes / 1000000000.0;
                return String.Format("{0:0.00}", gb) + "GB";
            }
        }

        public static void WriteToLog(string message)
        {
            CacherApp.AppViewModel.OutputText += message + System.Environment.NewLine;
        }

        private static void InitializeAppData()
        {
            SavedAppState savedState = LoadAppState();

            CacherApp.AppViewModel.SsdPath = savedState.SsdPath;
            CacherApp.AppViewModel.GameEntries = new ObservableCollection<GameEntry>(savedState.GameEntries.Select(savedEntry => new GameEntry()
            {
                Title = savedEntry.Title,
                SourcePath = savedEntry.SourcePath,
                TargetDirectory = savedEntry.TargetPath
            }));

            foreach (GameEntry entry in CacherApp.AppViewModel.GameEntries)
            {
                entry.IsCached = Utilities.DetermineIsCached(entry);
            }
        }

        private static SavedAppState LoadAppState()
        {
            SavedAppState savedState = new SavedAppState();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SavedAppState));
                using (StreamReader reader = new StreamReader(CacherApp.ConfigFileName))
                {
                    savedState = (SavedAppState)serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not load application configuration.", "Error");
            }

            return savedState;
        }

        public static void SaveAppState()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SavedAppState));
                SavedAppState appState = CacherApp.GetAppStateObject();
                using (StreamWriter writer = new StreamWriter(CacherApp.ConfigFileName))
                {
                    serializer.Serialize(writer, appState);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not save application configuration.", "Error");
            }
        }

        private static SavedAppState GetAppStateObject()
        {
            SavedAppState appState = new SavedAppState();

            appState.SsdPath = CacherApp.AppViewModel.SsdPath;
            appState.GameEntries = CacherApp.AppViewModel.GameEntries.Select(entry => new SavedGameEntry(entry)).ToList();

            return appState;
        }
    }
}
