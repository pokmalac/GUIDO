using GUIDO.Resources;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUIDO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void convertBtn_Click(object sender, RoutedEventArgs e)
        {
            this.convertBtn.IsEnabled = false;
            this.HideAndClearError();

            string rawText = this.simlpleGuidInput.Text;
            if (Guid.TryParse(rawText, out Guid parsedGuid))
            {
                this.simpleFormGuidBox.Text = parsedGuid.ToString("N");
                this.properFormGuidBox.Text = parsedGuid.ToString();
                this.copySimpleBtn.Visibility = Visibility.Visible;
                this.copyProperBtn.Visibility = Visibility.Visible;
            }
            else
            {
                this.ShowError(GuidoResource.InvalidGuid);
                this.ClearFormattedValues();
            }
            this.convertBtn.IsEnabled = true;
        }

        private void simlpleGuidInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.HideAndClearError();
        }

        private void HideAndClearError()
        {
            if (this.simpleErrorLabel != null && this.simpleErrorLabel.Visibility == Visibility.Visible)
            {
                this.simpleErrorLabel.Visibility = Visibility.Collapsed;
                this.simpleErrorLabel.Content = string.Empty;
            }
        }

        private void ShowError(string error)
        {
            this.simpleErrorLabel.Visibility = Visibility.Visible;
            this.simpleErrorLabel.Content = error;
        }

        private void ClearFormattedValues()
        {
            this.properFormGuidBox.Clear();
            this.simpleFormGuidBox.Clear();
            this.copySimpleBtn.Visibility = Visibility.Hidden;
            this.copyProperBtn.Visibility = Visibility.Hidden;
        }

        private void copySimpleBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.simpleFormGuidBox.Text);
        }

        private void copyProperBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(this.properFormGuidBox.Text);

        }
    }
}
