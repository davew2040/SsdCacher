using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsdCacher.Code.ViewModels
{
    public class GameEntry : SsdCacherViewModel
    {
        public GameEntry()
        {
            this.Title = string.Empty;
            this.SourcePath = string.Empty;
            this.TargetDirectory = string.Empty;
            this.IsCached = false;
        }

        public GameEntry Clone()
        {
            GameEntry newEntry = new GameEntry()
            {
                Title = this.Title,
                SourcePath = this.SourcePath,
                TargetDirectory = this.TargetDirectory,
                IsCached = this.IsCached
            };

            return newEntry;
        }

        public void CopyFrom(GameEntry otherEntry)
        {
            this.Title = otherEntry.Title;
            this.SourcePath = otherEntry.SourcePath;
            this.TargetDirectory = otherEntry.TargetDirectory;
            this.IsCached = otherEntry.IsCached;
        }

        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                OnPropertyChanged();
            }
        }
        
        private string sourcePath;
        public string SourcePath
        {
            get
            {
                return this.sourcePath;
            }
            set
            {
                this.sourcePath = value;
                OnPropertyChanged();
            }
        }

        private string targetPath;
        public string TargetDirectory
        {
            get
            {
                return this.targetPath;
            }
            set
            {
                this.targetPath = value;
                OnPropertyChanged();
            }
        }

        private bool isCached;
        public bool IsCached
        {
            get
            {
                return this.isCached;
            }
            set
            {
                this.isCached = value;
                OnPropertyChanged();
            }
        }
    }
}
