using System;
using System.IO;
using SsdCacher.Code.Logger;
using System.Linq;
using static SsdCacher.Code.FileCopier;
using SsdCacher.Code.ViewModels;

namespace SsdCacher.Code
{
    public class FileManager
    {
        public const string TempPathPostfix = ".temp";

        public static void CacheGame(GameEntry game, string ssdPath, ILogger logger, Action<FileCopyProgress> statusUpdater)
        {
            string ssdFullPath = ssdPath + Path.DirectorySeparatorChar + game.TargetDirectory;

            if (!Directory.Exists(ssdPath))
            {
                throw new FileManagerException("Target directory does not exist.");
            }

            if (!Directory.Exists(game.SourcePath))
            {
                throw new FileManagerException("Source path does not exist.");
            }

            if (Directory.Exists(ssdFullPath))
            {
                if (!FileManager.DirectoryIsEmpty(ssdFullPath))
                {
                    throw new FileManagerException("SSD path already exists and is not empty.");
                }
            }
            else
            {
                Directory.CreateDirectory(ssdFullPath);
            }

            FileCopier.CopyAll(game.SourcePath, ssdFullPath, logger, statusUpdater);

            logger.WriteLine(String.Format("Copied {0} to {1}.", game.SourcePath, ssdFullPath));

            string temporarySourcePath = game.SourcePath + FileManager.TempPathPostfix;

            Directory.Move(game.SourcePath, temporarySourcePath);

            SymLinkCreator.CreateSymbolicDirectoryLink(game.SourcePath, ssdFullPath);

            logger.WriteLine(String.Format("Created symbolic link at {0}.", game.SourcePath));

            Directory.Delete(temporarySourcePath, true);

            logger.WriteLine(String.Format("Deleting {0}.", temporarySourcePath));
        }

        public static void UncacheGame(GameEntry game, string ssdPath, ILogger logger, Action<FileCopyProgress> statusUpdater)
        {
            string ssdFullPath = ssdPath + Path.DirectorySeparatorChar + game.TargetDirectory;

            if (!Directory.Exists(ssdPath))
            {
                throw new FileManagerException("Target directory does not exist.");
            }

            if (!Directory.Exists(game.SourcePath))
            {
                throw new FileManagerException("Source symlink does not exist.");
            }

            if (Directory.Exists(ssdFullPath))
            {
                if (FileManager.DirectoryIsEmpty(ssdFullPath))
                {
                    throw new FileManagerException("SSD path exists but is not empty.");
                }
            }
            else
            {
                throw new FileManagerException("SSD path does not exist.");
            }

            Directory.Delete(game.SourcePath);

            FileCopier.CopyAll(ssdFullPath, game.SourcePath, logger, statusUpdater);

            Directory.Delete(ssdFullPath, true);
        }

        private static bool DirectoryIsEmpty(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new Exception("Directory does not exist.");
            }

            return !Directory.GetFiles(path).Any() && Directory.GetDirectories(path).Any();
        }

        public class FileManagerException : Exception
        {
            public FileManagerException(string message) : base(message)
            {
            }
        }
    }
}
