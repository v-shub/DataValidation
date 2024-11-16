using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ArtifactLibrary;

namespace Artifacts
{
    /// <summary>
    /// Логика взаимодействия для CurrencyWindow.xaml
    /// </summary>
    public partial class CurrencyWindow : Window
    {
        string[] currencies = { "r", "$", "euro", "Rs", "f", "Fr", "Ps" };
        public string[] Currencies
        {
            get { return currencies; }
            set { currencies = value; }
        }
        public CurrencyWindow()
        {
            InitializeComponent();
            CurrencyComboBox.ItemsSource = Currencies;
        }

        private void SetCurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow owner = (MainWindow)this.Owner;
            int currIndex = CurrencyComboBox.SelectedIndex;
            string exchangeRatePattern = @"^\d+,\d\d$";
            double exchangeRate = Regex.IsMatch(ExchangeRateBox.Text, exchangeRatePattern) ? Convert.ToDouble(ExchangeRateBox.Text):owner.ExchangeRates[currIndex];
            owner.ExchangeRates[currIndex] = exchangeRate;
            if (ConvertCurrencyCheckBox.IsChecked == true)
            {
                foreach (Artifact artifact in owner.Artifacts)
                    artifact.ChangeCurrency(exchangeRate / owner.ExchangeRates[owner.LastCurrencyIndex], Currencies[currIndex]);
                owner.LastCurrencyIndex = currIndex;
            }
            this.Close();
        }

        private void CurrencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow owner = (MainWindow)this.Owner;
            ExchangeRateBox.Text = owner.ExchangeRates[CurrencyComboBox.SelectedIndex].ToString();
        }
    }
}
