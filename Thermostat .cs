using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Älytalo
{
    public class Thermostat
    {
        public int Temperature { get; private set; } = 20;

        public void SetTempature(string t, TextBox temperature, TextBox newTemperature, Label lb)
        {
            t = newTemperature.Text.Replace("°C", " ").TrimEnd();
            if (Checker.IsNumeric(t, 1, 50))
            {
                Temperature = int.Parse(t);
                temperature.Text = t.ToString() + "°C";
                newTemperature.Text = "";
                lb.Content = t.ToString() + "°C";
            }
        }
    }
}
