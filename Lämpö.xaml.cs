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
using System.Xml.Linq;

namespace Älytalo
{
    /// <summary>
    /// Interaction logic for Lämpö.xaml
    /// </summary>
    public partial class Lämpö : Page
    {
        Thermostat thermostat = new();
        public Lämpö()
        {
            InitializeComponent();
            TxtLampotila.Text = thermostat.Temperature.ToString() + "°C";
            
        }

        private void PlusMinus_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (TxtUusiLampotila.Text == "")
            {
                TxtUusiLampotila.Text = TxtLampotila.Text;
            }
            string temp = TxtUusiLampotila.Text.Replace("°C", " ").TrimEnd();
            if (Checker.IsNumeric(temp, 1, 50))
            {
                int t = int.Parse(temp);
                if (sender == BtnMinus && t > 1)
                {
                    t--;
                }
                if (sender == BtnPlus && t < 50)
                {
                    t++;
                }
                TxtUusiLampotila.Text = t.ToString() + "°C";
            }
        }

        private void BtnAsetaLampo_Click(object sender, RoutedEventArgs e)
        {
            thermostat.SetTempature(TxtLampotila.Text, TxtLampotila, TxtUusiLampotila,
                ((MainWindow)Application.Current.MainWindow).LbAsteetMain);
        }
    }
}
