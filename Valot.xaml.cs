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

namespace Älytalo
{
    /// <summary>
    /// Interaction logic for Valot.xaml
    /// </summary>
    
    public partial class Valot : Page
    {
        Lights keittioL;
        Lights olohuoneL;
        Lights saunaL;
        public Valot()
        {
            InitializeComponent();
            TxtKeittioVal.Text = "0 %";
            TxtOlohuoneVal.Text = "0 %";
            TxtSaunaVal.Text = "0 %";
            BtnKeittioVal.Background = Brushes.Red;
            BtnOlohuoneVal.Background = Brushes.Red;
            BtnSaunaVal.Background = Brushes.Red;

            keittioL = new(SlidKeittio, BtnKeittioVal, TxtKeittioVal);
            olohuoneL = new(SlidOlohuone, BtnOlohuoneVal, TxtOlohuoneVal);
            saunaL = new(SlidSauna, BtnSaunaVal, TxtSaunaVal);
        }
        private void SliderLights_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //Hoitaa kaikista slidereista lähtevät muutokset
        {
            
            if (sender == SlidKeittio)
            {
                keittioL.Adjust(SlidKeittio.Value.ToString(),
                    ((MainWindow)Application.Current.MainWindow).BordKeittio);
            }
            if (sender == SlidOlohuone)
            {
                olohuoneL.Adjust(SlidOlohuone.Value.ToString(),
                    ((MainWindow)Application.Current.MainWindow).BordOlohuone);
            }
            if (sender == SlidSauna)
            {
                saunaL.Adjust(SlidSauna.Value.ToString(),
                    ((MainWindow)Application.Current.MainWindow).BordSauna);
            }
        }

        private void BtnLights_Click(object sender, RoutedEventArgs e)
        //Hoitaa buttoneista lähtevät muutokset
        {
            
            if (sender == BtnKeittioVal)
            {
                if (keittioL.Switced)
                {
                    keittioL.Adjust("0", ((MainWindow)Application.Current.MainWindow).BordKeittio);
                }
                else
                {
                    keittioL.Adjust("100", ((MainWindow)Application.Current.MainWindow).BordKeittio);
                }
            }
            if (sender == BtnOlohuoneVal)
            {
                if (olohuoneL.Switced)
                {
                    olohuoneL.Adjust("0", ((MainWindow)Application.Current.MainWindow).BordOlohuone);
                }
                else
                {
                    olohuoneL.Adjust("100",((MainWindow)Application.Current.MainWindow).BordOlohuone);
                }
            }
            if (sender == BtnSaunaVal)
            {
                if (saunaL.Switced)
                {
                    saunaL.Adjust("0", ((MainWindow)Application.Current.MainWindow).BordSauna);
                }
                else
                {
                    saunaL.Adjust("100", ((MainWindow)Application.Current.MainWindow).BordSauna);
                }
            }
        }
        private void TxtLights_LostFocus(object sender, RoutedEventArgs e)
        //Hoitaa tekstikenttistä lähtevät muutokset, tekstikenttiin voi manuaalisesti laittaa
        //valaistuksen vahvuuden, päivittyy kun focus siirtyy pois tekstikentästä
        {
            
            if (sender == TxtKeittioVal)
            {
                LightTextSettingRoutine(keittioL, TxtKeittioVal, SlidKeittio,
                    ((MainWindow)Application.Current.MainWindow).BordKeittio);
            }
            if (sender == TxtOlohuoneVal)
            {
                LightTextSettingRoutine(olohuoneL, TxtOlohuoneVal, SlidOlohuone,
                    ((MainWindow)Application.Current.MainWindow).BordOlohuone);
            }
            if (sender == TxtSaunaVal)
            {
                LightTextSettingRoutine(saunaL, TxtSaunaVal, SlidSauna,
                    ((MainWindow)Application.Current.MainWindow).BordSauna);
            }
        }
        void LightTextSettingRoutine(Lights light, TextBox txt, Slider slid, Border bord )
        //Sisennys funktio tekstikentistä lähteviin muutoksiin
        {
            string temp = txt.Text.Replace('%', ' ').TrimEnd();
            if (Checker.IsNumeric(temp, 0, 100))
            {
                light.Adjust(temp, bord);
            }
            else
            {
                txt.Text = slid.Value.ToString("F0") + "%";
            }
        }
    }
}
