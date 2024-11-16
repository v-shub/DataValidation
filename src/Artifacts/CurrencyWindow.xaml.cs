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
using System.Windows.Shapes;

namespace Artifacts
{
    /// <summary>
    /// Логика взаимодействия для CurrencyWindow.xaml
    /// </summary>
    public partial class CurrencyWindow : Window
    {
        double[] exchangeRates = { 1, 100, 105.71, 1.18, 0.26, 112.58, 127.08 };
        string[] currencies = { "r", "$", "euro", "Rs", "f", "Fr", "Ps" };
        double[] ExchangeRates
        {
            get {  return exchangeRates; }
            set { exchangeRates = value; }
        }
        string[] Currencies
        {
            get { return currencies; }
            set { currencies = value; }
        }
        public CurrencyWindow()
        {
            InitializeComponent();
            CurrencyComboBox.ItemsSource = Currencies;
            CurrencyComboBox.SelectedIndex = 0;
        }

        private void SetCurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            ExchangeRates[CurrencyComboBox.SelectedIndex] = Convert.ToDouble(ExchangeRateBox.Text);
            //if (ConvertCurrencyCheckBox.IsChecked)
                
            this.Close();
        }

        private void CurrencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExchangeRateBox.Text = ExchangeRates[CurrencyComboBox.SelectedIndex].ToString();
        }
    }
}
