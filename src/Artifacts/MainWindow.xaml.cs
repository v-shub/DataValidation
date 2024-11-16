using ArtifactLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Artifacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Artifact> artifacts = new List<Artifact>();
        int lastCurrencyIndex = 0;
        double[] exchangeRates = { 1, 100, 105.71, 1.18, 0.26, 112.58, 127.08 };
        public List<Artifact> Artifacts {
            get { return artifacts; }
            set { artifacts = value; }
        }
        public int LastCurrencyIndex
        {
            get { return lastCurrencyIndex; }
            set { lastCurrencyIndex = value; }
        }
        public double[] ExchangeRates
        {
            get { return exchangeRates; }
            set { exchangeRates = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            Artifacts.Add(new Artifact("AAA", 10, -5, 23, 100, "r", "Gold", "Anemo"));
            Artifacts.Add(new Artifact("BBB", -3, 20, -23, 30.5, "r", "Silver", "Geo"));
            ArtifactGrid.ItemsSource = Artifacts;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ArtifactWindow pw = new ArtifactWindow(1);
            pw.Owner = this;
            pw.Show();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            ArtifactWindow pw = new ArtifactWindow(2);
            pw.Owner = this;
            pw.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ArtifactWindow pw = new ArtifactWindow(3);
            pw.Owner = this;
            pw.Show();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            Artifacts = new List<Artifact>
            {
                new Artifact("AAA", 10, -5, 23, 100, "r", "Gold", "Anemo"),
                new Artifact("BBB", -3, 20, -23, 30.5, "r", "Silver", "Geo")
            };
            LastCurrencyIndex = 0;
            ExchangeRates = new double[] { 1, 100, 105.71, 1.18, 0.26, 112.58, 127.08 };
            ArtifactGrid.ItemsSource = Artifacts;
        }

        private void CurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            CurrencyWindow pw = new CurrencyWindow();
            pw.Owner = this;
            pw.Show();
        }
    }
}
