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
using Bitcoin.BIP39;

namespace TestGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BIP39.Language _language = BIP39.Language.English;
        BIP39 bip39er;
        bool init = true;
           
        public MainWindow()
        {
            InitializeComponent();
            init = false;
            //create an initial BIP39 object to display values on first open of GUI  
            bip39er = new BIP39(Convert.ToInt32(entropyDrop.SelectedValue), tbPassphrase.Text, _language);
            UpdateGUI();
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!init)
            {
                //create new BIP39 object with new entropy bits
                bip39er = await DoBIP39();
                UpdateGUI();
            }
        }

        private async Task<BIP39> DoBIP39()
        {
            //create a new BIP39 object, this in turn generates new random entropy bits
            return await BIP39.GetBIP39Async(Convert.ToInt32(entropyDrop.SelectedValue), tbPassphrase.Text, _language);
        }

        private void UpdateGUI()
        {
            //reads values from the BIP39 object and reports them via the GUI
            lblWordCount.Text = bip39er.WordCountFromEntropy.ToString();
            tbMnemonicScentence.Text = bip39er.MnemonicSentence;
            tbSeedBytesHex.Text = bip39er.SeedBytesHexString;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if(!init)
            {
                if (langDrop.SelectedIndex == 1)
                {
                    _language = BIP39.Language.Japanese;
                }
                else if (langDrop.SelectedIndex == 2)
                {
                    _language = BIP39.Language.Spanish;
                }
                else if (langDrop.SelectedIndex == 3)
                {
                    _language = BIP39.Language.ChineseSimplified;
                }
                else if (langDrop.SelectedIndex == 4)
                {
                    _language = BIP39.Language.ChineseTraditional;
                }
                else
                {
                    _language = BIP39.Language.English;
                }

                //set the language to use on the BIP39 object
                bip39er.WordlistLanguage = _language;

                //refreshing the GUI forces the BIP39 object to report it's values using the new language
                UpdateGUI();
            }
        }

        private void tbPassphrase_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!init)
            {
                //set the passphrase to use on the BIP39 object
                bip39er.Passphrase = tbPassphrase.Text;

                //refreshing the GUI forces the BIP39 object to report it's values using the new passphrase
                UpdateGUI();

            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //create a new BIP39 object therefore new entropy bits
           bip39er = await DoBIP39();
           UpdateGUI();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Bitcoin:1ETQjMkR1NNh4jwLuN5LxY7bMsHC9PUPSV");
            }
            catch
            {

            }
        }
    }
}
