using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsdCacher.Code.Save
{
    [Serializable]
    public class SavedAppState
    {
        public string SsdPath { get; set; }

        private List<SavedGameEntry> gameEntries = new List<SavedGameEntry>();
        public List<SavedGameEntry> GameEntries
        {
            get
            {
                if (this.gameEntries == null)
                {
                    return new List<SavedGameEntry>();
                }

                return this.gameEntries;
            }
            set
            {
                this.gameEntries = value.ToList();
            }
        }
    }
}
