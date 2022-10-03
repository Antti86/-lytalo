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
        Valot valo = new();
        Lämpö lampo = new();
        public MainWindow()
        {
            InitializeComponent();
            Page.NavigationService.Navigate(valo);
            LbAsteetMain.Content = "20°C";
        }
        private void BtnLammitysNav_Click(object sender, RoutedEventArgs e)
        {
            Page.NavigationService.Navigate(lampo);
        }

        private void BtnValotNav_Click(object sender, RoutedEventArgs e)
        {
            Page.NavigationService.Navigate(valo);
        }

    }
}
