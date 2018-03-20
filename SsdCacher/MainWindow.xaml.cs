using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SsdCacher.Code;
using SsdCacher.Code.ViewModels;
using SsdCacher.Dialogs;

namespace SsdCacher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!this.IsAdministrator())
            {
                MessageBox.Show("This application must be run as administrator to function correctly!", "Error");
                System.Windows.Application.Current.Shutdown();
            }
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public AppViewModel AppViewModel
        {
            get { return CacherApp.AppViewModel; }
            private set { }
        }

        private void Cache_Click(object sender, RoutedEventArgs e)
        {
            CacherApp.CacheGame(this.AppViewModel.SelectedGameEntry);
        }

        private void Uncache_Click(object sender, RoutedEventArgs e)
        {
            CacherApp.UncacheGame(this.AppViewModel.SelectedGameEntry);
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            AddEditGameWindow cw = new AddEditGameWindow(AddEditGameWindow.AddEditMode.Add);
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;

            GameEntry newGameEntry = new GameEntry();
            cw.DataContext = newGameEntry;
            bool? dialogResult = cw.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value == true)
            {
                CacherApp.AppViewModel.GameEntries.Add(newGameEntry);
                CacherApp.SaveAppState();
            }
        }

        private void EditGame_Click(object sender, RoutedEventArgs e)
        {
            AddEditGameWindow cw = new AddEditGameWindow(AddEditGameWindow.AddEditMode.Edit);
            cw.ShowInTaskbar = false;
            cw.Owner = Application.Current.MainWindow;

            if (CacherApp.AppViewModel.SelectedGameEntry == null)
            {
                throw new Exception("Must have a selected game entry.");
            }

            GameEntry clonedEntry = CacherApp.AppViewModel.SelectedGameEntry.Clone();
            cw.DataContext = clonedEntry;
            bool? dialogResult = cw.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value == true)
            {
                CacherApp.AppViewModel.SelectedGameEntry.CopyFrom(clonedEntry);

                CacherApp.SaveAppState();
            }
        }

        private void btn_findSsdPath_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (Directory.Exists(CacherApp.AppViewModel.SsdPath))
                {
                    dialog.SelectedPath = CacherApp.AppViewModel.SsdPath;
                }

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    CacherApp.AppViewModel.SsdPath = dialog.SelectedPath;
                }
            }
        }
    }
}
