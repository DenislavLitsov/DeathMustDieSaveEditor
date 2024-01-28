using DeathMustDieSaveEditor.Core.Models.SaveStructure;
using System.Windows;
using System.Windows.Controls;
using Button = System.Windows.Controls.Button;
using Label = System.Windows.Controls.Label;
using TextBox = System.Windows.Controls.TextBox;

namespace DeathMustDieSaveEditor.WPF.Helpers
{
    internal class MainWindowItemAttributeHelper
    {
        private readonly Grid grid;

        private int AttributeCount = 0;
        private int PixelHeightDifference = 25;

        private Item CurrItem = null;

        public MainWindowItemAttributeHelper(Grid grid)
        {
            this.grid = grid;
        }

        public void InitializeItem(Item item)
        {
            if (this.CurrItem != null)
                this.DeleteAllAttributeLines();

            this.CurrItem = item;
            foreach (Affix affix in this.CurrItem.Affixes)
            {
                this.CreateNewAttributeLine(affix.GetName(), affix.Levels.ToString());
            }
        }

        private void CreateNewAttributeLine(string labelText, string textBoxValue)
        {
            Label dynamicLabel = new Label();
            dynamicLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            dynamicLabel.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            dynamicLabel.Margin = new System.Windows.Thickness(10, 157 + PixelHeightDifference * AttributeCount, 0, 0);
            dynamicLabel.Content = labelText;
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

            Button btn = new Button();

            btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            btn.Margin = new System.Windows.Thickness(241, 161 + PixelHeightDifference * AttributeCount, 0, 0);
            btn.Name = $"AttributeDeleteButton{AttributeCount}";
            btn.Height = 20;
            btn.Width = 39;
            btn.Content = "Delete";
            btn.Click += new RoutedEventHandler(ButtonAttributeDelete_Click);

            this.grid.Children.Add(dynamicLabel);
            this.grid.Children.Add(txtb);
            this.grid.Children.Add(btn);
            this.AttributeCount++;
        }

        private void DeleteAllAttributeLines()
        {
            this.grid.Children.RemoveRange(1, AttributeCount * 3);
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

            foreach (var child in this.grid.Children)
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

            this.grid.Children.Remove(myTextBlock);
            this.grid.Children.Remove(myTextLabel);
            this.grid.Children.Remove(myButton);
        }

        private void AffixWasChanged(int lineNumber, string newValue)
        {

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
