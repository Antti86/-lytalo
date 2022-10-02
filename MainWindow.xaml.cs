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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lights keittioL = new();
        Lights olohuoneL = new();
        Lights saunaL = new();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void SliderLights_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            //Hoitaa kaikista slidereista lähtevät muutokset
        {
            if (sender == SlidKeittio)
            {
                keittioL.Adjust(SlidKeittio.Value.ToString(),SlidKeittio, BordKeittio, BtnKeittioVal,
                    TxtKeittioVal);
            }
            if (sender == SlidOlohuone)
            {
                olohuoneL.Adjust(SlidOlohuone.Value.ToString(),SlidOlohuone, BordOlohuone,
                    BtnOlohuoneVal, TxtOlohuoneVal);
            }
            if (sender == SlidSauna)
            {
                saunaL.Adjust(SlidSauna.Value.ToString(), SlidSauna, BordSauna, BtnSaunaVal,
                    TxtSaunaVal);
            }
        }

        private void BtnLights_Click(object sender, RoutedEventArgs e)
            //Hoitaa buttoneista lähtevät muutokset
        {
            if (sender == BtnKeittioVal)
            {
                if (keittioL.Switced)
                {
                    keittioL.Adjust("0", SlidKeittio, BordKeittio, BtnKeittioVal, TxtKeittioVal);
                }
            }
            if (sender == BtnOlohuoneVal)
            {
                if (olohuoneL.Switced)
                {
                    olohuoneL.Adjust("0", SlidOlohuone, BordOlohuone, BtnOlohuoneVal, TxtOlohuoneVal);
                }
            }
            if (sender == BtnSaunaVal)
            {
                if (saunaL.Switced)
                {
                    saunaL.Adjust("0", SlidSauna, BordSauna, BtnSaunaVal, TxtSaunaVal);
                }
            }
        }

        private void TxtLights_LostFocus(object sender, RoutedEventArgs e)
            //Hoitaa tekstikenttistä lähtevät muutokset, tekstikenttiin voi manuaalisesti laittaa
            //valaistuksen vahvuuden, päivittyy kun focus siirtyy pois tekstikentästä
        {
            if (sender == TxtKeittioVal)
            {
                LightTextSettingRoutine(keittioL, TxtKeittioVal, SlidKeittio, BordKeittio, BtnKeittioVal);
            }
            if (sender == TxtOlohuoneVal)
            {
                LightTextSettingRoutine(olohuoneL, TxtOlohuoneVal, SlidOlohuone, BordOlohuone,
                    BtnOlohuoneVal);
            }
            if (sender == TxtSaunaVal)
            {
                LightTextSettingRoutine(saunaL, TxtSaunaVal, SlidSauna, BordSauna, BtnSaunaVal);
            }
        }
        void LightTextSettingRoutine(Lights light, TextBox txt, Slider slid, Border bord, Button btn)
            //Sisennys funktio tekstikentistä lähteviin muutoksiin
        {
            string temp = txt.Text.Replace('%', ' ').TrimEnd();
            if (Checker.IsNumeric(temp, 0, 100))
            {
                light.Adjust(temp, slid, bord, btn, txt);
            }
            else
            {
                txt.Text = slid.Value.ToString("F0") + "%";
            }
        }
    }
}
