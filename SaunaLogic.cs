using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Älytalo
{
    public class SaunaLogic //Nimi SaunaLogic koska Sauna oli jo page nimenä
    {
        private bool Switched = false;
        private int Temperature = 20;
        //Nämä private fieldeinä vahvan kapseloinnin takia

        public void Start(Label label)
            //Ottaa mainwindown labelistä talon lämpötilan
        {
            if (label is not null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string temp = label.Content.ToString().Replace("°C", " ").TrimEnd();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                if (Checker.IsNumeric(temp))
                {
                    Temperature = Convert.ToInt32(temp);
                }
            }
            
            Switched = true;            
        }

        public void Stop()
        {
            Switched = false;

        }

        public void Update(DispatcherTimer heater, TextBox status, TextBox tempa, Label label,
            Label mainlb)
            //Päivittää kaikki tekstikentät ja logiikan kun timeri on aktiivinen
        {
            if (Switched)
            {
                Temperature++;
                
                if (Temperature < 80)
                {
                    status.Text = "Lämpenee!";
                }
                else if (Temperature > 80 && Temperature <= 120)
                {
                    status.Text = "Sauna valmis!";
                }
                else if (Temperature >= 119)
                {
                    heater.Stop();
                }
            }
            else
            {
                Temperature--;
                status.Text = "Viilenee!";
                int housetemperature;
                if (label is not null) //Ottaa mainwindows labelistä lämpötilan mihin pysähtyä
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    string temp = label.Content.ToString().Replace("°C", " ").TrimEnd();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    if (Checker.IsNumeric(temp))
                    {
                        housetemperature = Convert.ToInt32(temp);
                        if (Temperature <= housetemperature)
                        {
                            heater.Stop();
                            status.Text = "";
                        }
                    }
                }

            }
            tempa.Text = Temperature.ToString() + "°C";
            mainlb.Content = Temperature.ToString() + "°C";
        }
    }
}
