using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Älytalo
{
    public class Lights
    {
        public Lights(Slider slid_in, Button swit_in, TextBox box_in)
        {
            slid = slid_in;
            swit = swit_in;
            box = box_in;
            Dimmer = "";
            Switced = false;
        }
        private TextBox box;
        private Slider slid;
        private Button swit;
        public bool Switced { get; private set; }
        //Set metodi on private ettei sitä voi vahingossa muuttaa tän luokan ulkopuolelta
        private string Dimmer;
        //Vahvan kapselloinnin takia vain Adjust metodi voi muuttaa Dimmerin arvoa
        public void Adjust(string dimmer, Border bord)
            //Metodi muuttaa sliderin, borderin, txtboksin ja On/Off buttonin arvoa Dimmerin mukaan
        {
            Dimmer = dimmer;
            if (Checker.IsDecimal(Dimmer) || Checker.IsNumeric(Dimmer))
                //Varmistetaan että dimmerin arvo on numeroita tai desimaaleja
            {
                double dim = double.Parse(Dimmer);
                //Muutetaan dimmerin arvo doubleks
                slid.Value = dim;
                //Asetetaan Sliderin arvo Dimmerin mukaan
                bord.Background.Opacity = dim / 100;
                //Asetetaan border objektin alpha värikanava, valon vahvuus effektiä varten 
                box.Text = dim.ToString("F0") + "%";
                //Asetetaan tekstiboksiin valon vahvuus prosentteina ilman desimaaleja
                if (slid.Value == 0)
                {
                    swit.Content = "Off"; 
                    swit.Background = Brushes.Red;
                    Switced = false;
                }
                else
                {
                    swit.Content = "On";
                    swit.Background = Brushes.Green;
                    Switced = true;
                }
            }
        }
    }
}
