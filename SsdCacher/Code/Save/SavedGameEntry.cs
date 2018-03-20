using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SsdCacher.Code.ViewModels;

namespace SsdCacher.Code.Save
{
    [Serializable]
    public class SavedGameEntry
    {
        public SavedGameEntry()
        {

        }

        public SavedGameEntry(GameEntry entry)
        {
            this.Title = entry.Title;
            this.SourcePath = entry.SourcePath;
            this.TargetPath = entry.TargetDirectory;
        }

        public string Title { get; set; }

        public string SourcePath { get; set; }

        public string TargetPath { get; set; }
    }
}
