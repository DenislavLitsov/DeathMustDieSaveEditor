using DeathMustDieSaveEditor.Core.Logic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeathMustDieSaveEditor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataManager DataManager = new DataManager();

        private bool AreComponenteLoaded = false;

        public MainWindow()
        {
            InitializeComponent();
            this.AreComponenteLoaded = true;
            LoadDataManager();
        }

        private void LoadDataManager()
        {
            string loadedFilePath = this.DataManager.TryLoadSaveAlone();
            if (string.IsNullOrEmpty(loadedFilePath))
                return;

            var fileName = System.IO.Path.GetFileName(loadedFilePath);
            this.LoadedFileNameLabel.Content = fileName;
            this.LoadInitialValues();
        }

        private void LoadCustomSaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Save Files|*.sav";

            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;
            this.DataManager.LoadSave(filePath);

            var fileName = System.IO.Path.GetFileName(filePath);
            this.LoadedFileNameLabel.Content = fileName;

            this.LoadInitialValues();
        }

        private void LoadInitialValues()
        {
            this.GoldTextBox.Text = this.DataManager.GetGold().ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DataManager.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Changes are saved. Have Fun!", "Saved");
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void GoldTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!AreComponenteLoaded)
                return;

            string stringValue = this.GoldTextBox.Text;
            if (string.IsNullOrEmpty(stringValue))
            {
                stringValue = "0";
                this.GoldTextBox.Text = stringValue;
            }

            var newGoldValue = int.Parse(stringValue);
            this.DataManager.SetGold(newGoldValue);
        }
    }
}
