using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtifactLibrary
{
    public class Artifact
    {
        string name;
        int attackImpact;
        int hpImpact;
        int defenceImpact;
        double price;
        string currency;
        string material;
        string element;
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public int AttackImpact
        {
            get { return attackImpact; }
            set { attackImpact = value; }
        }
        public int HpImpact {
            get { return hpImpact; }
            set { hpImpact = value; }
        }
        public int DefenceImpact
        {
            get { return defenceImpact; }
            set { defenceImpact = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        public string Element
        {
            get { return element; }
            set { element = value; }
        }
        public Artifact() { }
        public Artifact(string name, int attackImpact, int hpImpact, int defenceImpact, double price, string currency, string material, string element)
        {
            Name = name;
            AttackImpact = attackImpact;
            HpImpact = hpImpact;
            DefenceImpact = defenceImpact;
            Price = price;
            Currency = currency;
            Material = material;
            Element = element;
        }
        public void ChangeCurrency(double exchRate, string newCurr)
        {
            Price /= exchRate;
            Currency = newCurr;
        }
    }
}
