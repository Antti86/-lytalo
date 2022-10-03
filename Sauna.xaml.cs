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
using System.Windows.Threading;

namespace Älytalo
{
    /// <summary>
    /// Interaction logic for Sauna.xaml
    /// </summary>
    public partial class Sauna : Page
    {
        SaunaLogic saunaLogic = new();
        public DispatcherTimer heater = new DispatcherTimer();
        public Sauna()
        {
            InitializeComponent();
            heater.Interval = new TimeSpan(0, 0, 1);
            heater.Tick += new EventHandler(heater_tick);
        }

        private void heater_tick(object? sender, EventArgs e)
        {
            saunaLogic.Update(heater, TxtSaunanTila, TxtSaunanLampotila,
                ((MainWindow)Application.Current.MainWindow).LbAsteetMain,
                ((MainWindow)Application.Current.MainWindow).LbSaunanAsteetMain);
        }

        private void BtnPäälle_Click(object sender, RoutedEventArgs e)
        {
            heater.Start();
            saunaLogic.Start(((MainWindow)Application.Current.MainWindow).LbAsteetMain);
        }

        private void BtnSammuta_Click(object sender, RoutedEventArgs e)
        {
            heater.Start();
            saunaLogic.Stop();
        }
    }
}
