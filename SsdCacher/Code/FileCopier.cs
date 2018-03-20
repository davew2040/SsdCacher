using System;
using System.IO;
using SsdCacher.Code.Logger;

namespace SsdCacher.Code
{
    public class FileCopier
    {
        public static void CopyAll(string sourceDirectory, string targetDirectory, ILogger logger, Action<FileCopyProgress> statusUpdater = null)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget, new FileCopyProgress(), logger, statusUpdater);
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target, FileCopyProgress progress, ILogger logger, Action<FileCopyProgress> statusUpdater)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                logger.WriteLine(String.Format(@"Copying {0}\{1}", target.FullName, fi.Name));
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                progress.FilesCount++;
                progress.FileSizeCopied += fi.Length;
                if (statusUpdater != null)
                {
                    statusUpdater(progress);
                }
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir, progress, logger, statusUpdater);
            }
        }

        public static FileCountInfo CountFiles(string sourceDirectory)
        {
            FileCountInfo fileCountInfo = new FileCountInfo();
            DirectoryInfo di = new DirectoryInfo(sourceDirectory);

            CountFilesRecursive(di, ref fileCountInfo);

            return fileCountInfo;
        }

        private static void CountFilesRecursive(DirectoryInfo sourceDirectory, ref FileCountInfo fileCountInfo)
        {
            CountFiles(sourceDirectory, ref fileCountInfo);
        }

        private static void CountFiles(DirectoryInfo source, ref FileCountInfo fileCountInfo)
        {
            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fileCountInfo.FilesCount++;
                fileCountInfo.FileSizeSum += fi.Length;
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSubDir in source.GetDirectories())
            {
                fileCountInfo.DirectoryCount++;
                CountFiles(diSubDir, ref fileCountInfo);
            }
        }

        public class FileCountInfo
        {
            public long FilesCount { get; set; }
            public long DirectoryCount { get; set; }
            public long FileSizeSum { get; set; }
        }


        public class FileCopyProgress
        {
            public long FilesCount { get; set; }
            public long FileSizeCopied { get; set; }
        }
    }
}
