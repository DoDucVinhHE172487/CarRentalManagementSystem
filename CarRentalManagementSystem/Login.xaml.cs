using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;
using BusinessObjects.Models;

namespace CarRentalManagementSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        CarRentalManagementSystemContext con;
        public Login()
        {
            InitializeComponent();
            con = new CarRentalManagementSystemContext();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = con.Staff.FirstOrDefault(x => x.Email == txtEmail.ToString());
            String jsonData = File.ReadAllText("appsettings.json");
            var adminAccount = JsonSerializer.Deserialize<Staff>(jsonData);
            if(staff != null && staff.Password.Equals(txtPassword.Password) && staff.IsDeleted == false)
            {
                this.Hide();
                //HomeCustomer homeCustomer = new HomeCustomer();
                //homeCustomer.Show();
            }else if (adminAccount!=null && adminAccount.Email.Equals(txtEmail.Text) && adminAccount.Password.Equals(txtPassword.Password))
            {
                this.Hide();
                ManageCar car = new ManageCar();
                car.Show();

            }
        }
    }
}
