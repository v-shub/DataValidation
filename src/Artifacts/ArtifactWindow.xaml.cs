using ArtifactLibrary;
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
using System.Text.RegularExpressions;

namespace Artifacts
{
    /// <summary>
    /// Логика взаимодействия для ArtifactWindow.xaml
    /// </summary>
    public partial class ArtifactWindow : Window
    {
        Artifact userArtifact = new Artifact();
        int funcNum;
        public Artifact UserArtifact
        {
            get { return userArtifact; }
            set { userArtifact = value; }
        }
        public ArtifactWindow(int num)
        {
            InitializeComponent();
            MaterialBox.ItemsSource = new string[] { "Gold", "Silver", "Bone", "Wood" };
            MaterialBox.SelectedIndex = 0;
            ElementBox.ItemsSource = new string[] { "Anemo", "Geo", "Pyro", "Hydro" };
            ElementBox.SelectedIndex = 0;
            funcNum= num;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow owner = (MainWindow)this.Owner;
            Artifact userArtifact = new Artifact();
            UserArtifact.Name = NameBox.Text;
            string pricePattern = @"^\d+(,\d\d)?\s(r|euro|\$|Rs|f|Fr|Ps)$";
            if (Regex.IsMatch(PriceBox.Text, pricePattern))
            {
                string[] priceParts = PriceBox.Text.Split();
                UserArtifact.Price = Convert.ToDouble(priceParts[0]);
                int thisCurrencyIndex = Array.IndexOf(owner.Currencies, priceParts[1]);
                UserArtifact.ChangeCurrency(owner.ExchangeRates[owner.LastCurrencyIndex] / owner.ExchangeRates[thisCurrencyIndex], owner.Currencies[owner.LastCurrencyIndex]);
            }
            else
            {
                UserArtifact.Price = 0;
                UserArtifact.Currency = "r";
            }
            string impactPattern = @"^-?\d+\s?%?$";
            if (Regex.IsMatch(AttackImpactBox.Text, impactPattern))
            {
                string attackImpact = AttackImpactBox.Text.Replace(" ", "").Replace("%", "");
                UserArtifact.AttackImpact = Convert.ToInt32(attackImpact);
            }
            else
                UserArtifact.AttackImpact = 0;
            if (Regex.IsMatch(DefenceImpactBox.Text, impactPattern))
            {
                string defenceImpact = DefenceImpactBox.Text.Replace(" ", "").Replace("%", "");
                UserArtifact.DefenceImpact = Convert.ToInt32(defenceImpact);
            }
            else
                UserArtifact.DefenceImpact = 0;
            if (Regex.IsMatch(HpImpactBox.Text, impactPattern))
            {
                string hpImpact = HpImpactBox.Text.Replace(" ", "").Replace("%", "");
                UserArtifact.HpImpact = Convert.ToInt32(hpImpact);
            }
            else
                UserArtifact.HpImpact = 0;
            UserArtifact.Material = MaterialBox.Text;
            UserArtifact.Element = ElementBox.Text;
            switch (funcNum)
            {
                case 1:
                    owner.Artifacts.Add(UserArtifact);
                    break;
                case 2:
                    Artifact changeArt = owner.Artifacts.Find(x => x.Name == UserArtifact.Name);
                    if (changeArt != null)
                    {
                        owner.Artifacts.Remove(changeArt);
                        owner.Artifacts.Add(UserArtifact);
                    }
                    break;
                case 3:
                    owner.Artifacts.Remove(owner.Artifacts.Find(x => x.Name == UserArtifact.Name));
                    break;
            }
            this.Close();
        }
    }
}
