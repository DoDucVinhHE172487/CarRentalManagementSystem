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

namespace CarRentalManagementSystem
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageCar manageCar = new ManageCar();
            manageCar.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ManageCarRental manageCarRental = new ManageCarRental();
            manageCarRental.Show();
        }
    }
}
