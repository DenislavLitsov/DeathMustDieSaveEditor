using DeathMustDieSaveEditor.Core.Logic;
using DeathMustDieSaveEditor.Core.Models;
using DeathMustDieSaveEditor.Core.Models.SaveStructure;
using DeathMustDieSaveEditor.WPF.Helpers;
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
using Label = System.Windows.Controls.Label;
using TextBox = System.Windows.Controls.TextBox;

namespace DeathMustDieSaveEditor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowHelper mainWindowHelper = new MainWindowHelper();
        private DataManager DataManager = new DataManager();

        private bool AreComponentsLoaded = false;

        private string[] HeroNames = ["Avoron", "Kront", "Merris", "Nixi", "Skadi"];

        private string SelectedClass = "Knight";

        private bool IsHeroUnlocked = false;

        private List<Item> LoadedItems;

        private int AttributeCount = 0;
        private int PixelHeightDifference = 25;

        public MainWindow()
        {
            InitializeComponent();
            foreach (var heroName in HeroNames)
            {
                this.HeroNameComboBox.Items.Add(heroName);
            }

            this.AreComponentsLoaded = true;
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
            this.HeroNameComboBox.SelectedIndex = 0;
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
            if (!AreComponentsLoaded)
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

        private void HeroNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = HeroNameComboBox.SelectedIndex;
            switch (index)
            {
                case 0:
                    this.SelectedClass = "Knight";
                    this.HeroAvatarImg.Source = new BitmapImage(new Uri(@"/Resources/Assets/Avoron.png", UriKind.Relative));
                    break;
                case 1:
                    this.SelectedClass = "Barbarian";
                    this.HeroAvatarImg.Source = new BitmapImage(new Uri(@"/Resources/Assets/Kront.png", UriKind.Relative));
                    break;
                case 2:
                    this.SelectedClass = "Sorceress";
                    this.HeroAvatarImg.Source = new BitmapImage(new Uri(@"/Resources/Assets/Witch.png", UriKind.Relative));
                    break;
                case 3:
                    this.SelectedClass = "Assassin";
                    this.HeroAvatarImg.Source = new BitmapImage(new Uri(@"/Resources/Assets/Nixi.png", UriKind.Relative));
                    break;
                case 4:
                    this.SelectedClass = "Warrior";
                    this.HeroAvatarImg.Source = new BitmapImage(new Uri(@"/Resources/Assets/Skadi.png", UriKind.Relative));
                    break;
                default:
                    break;
            }

            if (this.DataManager.IsHeroUnlocked(this.SelectedClass))
            {
                this.IsHeroUnlocked = true;
                this.LoadEquipment();
            }
            else
            {
                this.IsHeroUnlocked = false;
            }
        }

        private void LoadEquipment()
        {
            this.LoadedItems = this.DataManager.GetItems(this.SelectedClass)
                .ToList();
        }

        private void ItemSelectionImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // testing for creation
            this.CreateNewAttributeLine("Armor", "15");

            //var mousePosition = e.GetPosition(this.ItemSelectionImg);
            //var selection = this.mainWindowHelper.GetClickedType((int)mousePosition.X, (int)mousePosition.Y);
            //if (selection == ItemType.NONE)
            //    return;
            //
            //Console.WriteLine(selection.ToString());
            //var items = this.DataManager.GetItems(this.SelectedClass);
            //foreach (var item in items)
            //{
            //}
        }

        private void ItemWasClicked(ItemType itemType)
        {
            throw new NotImplementedException();
        }

        private void CreateNewAttributeLine(string labelText, string textBoxValue)
        {
            Label dynamicLabel = new Label();
            dynamicLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            dynamicLabel.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            dynamicLabel.Margin = new System.Windows.Thickness(10, 157 + PixelHeightDifference * AttributeCount, 0, 0);
            dynamicLabel.Content = labelText + AttributeCount;
            dynamicLabel.Name = $"AttributeLabel{AttributeCount}";
            dynamicLabel.Width = 240;
            dynamicLabel.Height = 30;

            TextBox txtb = new TextBox();
            txtb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            txtb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            txtb.Margin = new System.Windows.Thickness(92, 161 + PixelHeightDifference * AttributeCount, 0, 0);
            txtb.Name = $"AttributeValueTextBox{AttributeCount}";
            txtb.Height = 18;
            txtb.Width = 120;
            txtb.Text = textBoxValue;

            System.Windows.Controls.Button btn = new System.Windows.Controls.Button();

            btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btn.Margin = new System.Windows.Thickness(241, 161 + PixelHeightDifference * AttributeCount, 0, 0);
            btn.Name = $"AttributeDeleteButton{AttributeCount}";
            btn.Height = 20;
            btn.Width = 39;
            btn.Content = "Delete";
            btn.Click += new RoutedEventHandler(ButtonAttributeDelete_Click);

            this.AttributeGrid.Children.Add(dynamicLabel);
            this.AttributeGrid.Children.Add(txtb);
            this.AttributeGrid.Children.Add(btn);
            this.AttributeCount++;
        }

        private void DeleteAllAttributeLines()
        {

            AttributeGrid.Children.RemoveRange(1, AttributeCount * 3);
            AttributeCount = 0;
        }

        private void DeleteAttributeLine(int lineNumber)
        {
            string LabelName = $"AttributeLabel{lineNumber}";
            string TextBoxName = $"AttributeValueTextBox{lineNumber}";
            string ButtonName = $"AttributeDeleteButton{lineNumber}";

            TextBox myTextBlock = null;
            Label myTextLabel = null;
            System.Windows.Controls.Button myButton = null;

            foreach (var child in this.AttributeGrid.Children)
            {
                if (child is TextBox)
                {
                    var parsedChild = (TextBox)child;
                    if (parsedChild.Name == TextBoxName)
                    {
                        myTextBlock = parsedChild;
                    }
                }
                else if (child is Label)
                {
                    var parsedChild = (Label)child;
                    if (parsedChild.Name == LabelName)
                    {
                        myTextLabel = parsedChild;
                    }
                }
                else if (child is System.Windows.Controls.Button)
                {
                    var parsedChild = (System.Windows.Controls.Button)child;
                    if (parsedChild.Name == ButtonName)
                    {
                        myButton = parsedChild;
                    }
                }
            }

            this.AttributeGrid.Children.Remove(myTextBlock);
            this.AttributeGrid.Children.Remove(myTextLabel);
            this.AttributeGrid.Children.Remove(myButton);
        }

        private void LineWasChanged(int lineNumber, string newValue)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DeleteAllAttributeLines();
        }

        private void ButtonAttributeDelete_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            string Name = button.Name;
            int LetterCount = "AttributeDeleteButton".Length;
            string Number = Name.Substring(LetterCount, Name.Length - LetterCount);
            this.DeleteAttributeLine(int.Parse(Number));
        }
    }
}