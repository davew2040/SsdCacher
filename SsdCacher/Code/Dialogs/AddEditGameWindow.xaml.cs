using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SsdCacher.Code;
using SsdCacher.Code.ViewModels;

namespace SsdCacher.Dialogs
{
    /// <summary>
    /// Interaction logic for AddEditGame.xaml
    /// </summary>
    public partial class AddEditGameWindow : Window
    {
        public AddEditGameWindow(AddEditMode addEditMode)
        {
            InitializeComponent();

            this.addEditMode = addEditMode;

            if (this.addEditMode == AddEditMode.Add)
            {
                this.Title = "Add New Game";
                this.btn_Done.Content = "Add";
            }
            else
            {
                this.Title = "Edit Game";
                this.btn_Done.Content = "Save";
            }
        }

        private AddEditMode addEditMode;

        public enum AddEditMode
        {
            Add,
            Edit
        }

        private void Done_Button_Click(object sender, RoutedEventArgs e)
        {
            GameEntry gameEntry = (GameEntry)this.DataContext;

            gameEntry.SourcePath = gameEntry.SourcePath.Trim();
            gameEntry.TargetDirectory = gameEntry.TargetDirectory.Trim();
            gameEntry.Title = gameEntry.Title.Trim();

            if (string.IsNullOrEmpty(gameEntry.SourcePath) 
                || string.IsNullOrEmpty(gameEntry.TargetDirectory)
                || string.IsNullOrEmpty(gameEntry.Title))
            {
                MessageBox.Show("Must supply values for all fields.");
                return;
            }

            if (!Directory.Exists(gameEntry.SourcePath))
            {
                MessageBox.Show("Source path does not exist!");
                return;
            }

            if (this.addEditMode == AddEditMode.Add
                && CacherApp.AppViewModel.GameEntries.Any(existingGame => existingGame.Title.ToLower() == gameEntry.Title.ToLower()))
            {
                MessageBox.Show("A game with this title is already present.");
                return;
            }

            gameEntry.IsCached = Utilities.DetermineIsCached(gameEntry);

            this.DialogResult = true;
            this.Close();
        }

        private void FindSourcePath_Click(object sender, RoutedEventArgs e)
        {
            GameEntry gameEntry = (GameEntry)this.DataContext;

            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (Directory.Exists(gameEntry.SourcePath))
                {
                    dialog.SelectedPath = gameEntry.SourcePath;
                }

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    gameEntry.SourcePath = dialog.SelectedPath;
                }
            }
        }

        private void FindTargetPath_Click(object sender, RoutedEventArgs e)
        {
            GameEntry gameEntry = (GameEntry)this.DataContext;

            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (Directory.Exists(gameEntry.TargetDirectory))
                {
                    dialog.SelectedPath = gameEntry.TargetDirectory;
                }

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    gameEntry.TargetDirectory = dialog.SelectedPath;
                }
            }
        }
    }
}
