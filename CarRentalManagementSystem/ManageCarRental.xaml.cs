using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace CarRentalManagementSystem
{
    /// <summary>
    /// Interaction logic for ManageCarRental.xaml
    /// </summary>
    public partial class ManageCarRental : Window
    {
        CarRentalManagementSystemContext con;
        public ManageCarRental()
        {
            InitializeComponent();
            con = new CarRentalManagementSystemContext();
            loadCarRental();
            loadInfoCar();
            loadInfoCustomer();
            loadTime();
        }
        public void loadCarRental()
        {
            lvCarRental.ItemsSource = con.CarRentals.Include(x => x.Customer).Include(r => r.LicensePlatesNavigation).ToList();
        }
        public void loadInfoCar()
        {
            cbLicenPlates.ItemsSource = con.Cars.ToList();

        }
        public void loadInfoCustomer()
        {
            cbCustomerName.ItemsSource = con.Customers.ToList();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure want to cancel process?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Error);

            // Check if the "Yes" button was pressed
            if (result == MessageBoxResult.Yes)
            {
                // Close the current window
                Clear();
            }
        }
        public void Clear()
        {
            txtNameCar.Text = "";
            txtNumberOfSeats.Text = "";
            txtBrand.Text = "";
            txtColor.Text = "";
            txtPrice.Text = "";
            txtRentalPrice.Text = "";
            cbLicenPlates = null;
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            cbCustomerName = null;
        }

        private void cbLicenPlates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car carSelected = (sender as ComboBox).SelectedItem as Car;
            if (carSelected != null)
            {
                Car car = con.Cars.FirstOrDefault(x => x.LicensePlates == carSelected.LicensePlates);
                txtNameCar.Text = car.CarName;
                txtNumberOfSeats.Text = car.NumberOfSeats.ToString();
                txtBrand.Text = car.Brand;
                txtColor.Text = car.Color;
                txtPrice.Text = car.Price.ToString();
                txtRentalPrice.Text = car.RentalPrice.ToString();
            }
        }
        public void loadTime()
        {
            // Tạo danh sách các giá trị giờ
            var hours = Enumerable.Range(1, 24).Select(h => new ComboBoxItem { Content = h.ToString() });
            cbStartTimeHour.ItemsSource = hours;
            cbEndTimeHour.ItemsSource = hours;

            // Tạo danh sách các giá trị phút
            var minutes = Enumerable.Range(1, 60).Select(m => new ComboBoxItem { Content = m.ToString() });
            cbStartTimeMinute.ItemsSource = minutes;
            cbEndTimeMinute.ItemsSource = minutes;
        }
        private void cbCustomerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customerSelected = (sender as ComboBox).SelectedItem as Customer;
            if (customerSelected != null)
            {
                Customer customer = con.Customers.FirstOrDefault(x => x.CustomerId == customerSelected.CustomerId);
                txtPhoneNumber.Text = customer.PhoneNumber;
                txtAddress.Text = customer.Address;
            }
        }

        private void btnTotal_Click(object sender, RoutedEventArgs e)
        {
            if (dpEndTime.SelectedDate != null && dpStartTime.SelectedDate != null)
            {
                if (txtRentalPrice.Text.Length > 0)
                {
                   if(dpEndTime.SelectedDate < dpStartTime.SelectedDate)
                    {
                        DateTime dtStartTime = DateTime.Parse(dpStartTime.SelectedDate.ToString());
                        DateTime dtEndTime = DateTime.Parse(dpEndTime.SelectedDate.ToString());
                        TimeSpan timeSpan = dtEndTime - dtStartTime;
                        Double result = (Double)timeSpan.TotalMinutes;
                        Double rentalPrice = Double.Parse(txtRentalPrice.Text);
                        txtTotalPrice.Text = (rentalPrice * result).ToString();
                    }
                    else
                    {
                        MessageBox.Show("End Time can't be after Start Time", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Rental Price can't empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("StartTime or EndTime can't empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
