using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsdCacher.Code.ViewModels
{
    public class AppViewModel : SsdCacherViewModel
    {
        public AppViewModel()
        {
        }

        private string outputText = string.Empty;
        public string OutputText
        {
            get
            {
                return this.outputText;
            }

            set
            {
                this.outputText = value;
                OnPropertyChanged();
            }
        }

        private string statusText = string.Empty;
        public string StatusText
        {
            get
            {
                return this.statusText;
            }

            set
            {
                this.statusText = value;
                OnPropertyChanged();
            }
        }

        private string ssdPath = string.Empty;
        public string SsdPath
        {
            get
            {
                return this.ssdPath;
            }

            set
            {
                this.ssdPath = value;
                OnPropertyChanged();
                SsdPathUpdated();
            }
        }

        private GameEntry selectedGameEntry;
        public GameEntry SelectedGameEntry
        {
            get
            {
                return this.selectedGameEntry;
            }
            set
            {
                this.selectedGameEntry = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<GameEntry> gameEntries = new ObservableCollection<GameEntry>();
        public ObservableCollection<GameEntry> GameEntries
        {
            get
            {
                if (this.gameEntries == null)
                {
                    return new ObservableCollection<GameEntry>();
                }

                return this.gameEntries;
            }

            set
            {
                this.gameEntries = value;
                OnPropertyChanged();
            }
        }

        private bool isBusy = false;
        public bool IsBusy 
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.isBusy = value;
                OnPropertyChanged();
            }
        }
       
        private void SsdPathUpdated()
        {
            foreach (GameEntry game in this.GameEntries)
            {
                game.IsCached = Utilities.DetermineIsCached(game);
            }
        }
    }
}
