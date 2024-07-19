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
using BusinessObjects;
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

        private void btnManageCar_Click(object sender, RoutedEventArgs e)
        {
            ManageCar manageCar = new ManageCar();
            manageCar.Show();
        }

        private void btnManageCarRetal_Click(object sender, RoutedEventArgs e)
        {
           ManageCarRental manageCarRental = new ManageCarRental();
            manageCarRental.Show();
        }

        private void btnManageHistoryCarRental_Click(object sender, RoutedEventArgs e)
        {
            ManageHistoryCarRental manageHistoryCarRental = new ManageHistoryCarRental();
            manageHistoryCarRental.Show();
        }
    }
}
