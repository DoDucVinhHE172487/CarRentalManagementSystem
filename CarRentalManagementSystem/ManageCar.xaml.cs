using BusinessObject.Models;
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
    /// Interaction logic for ManageCar.xaml
    /// </summary>
    public partial class ManageCar : Window
    {
        CarRentalManagementSystemContext con;
        public ManageCar()
        {
            InitializeComponent();
            con = new CarRentalManagementSystemContext();
            loadCar();
        }
        public void loadCar()
        {
            lvCar.ItemsSource = con.Cars.Include(x => x.CarStatus).ToList();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Car car)
            {
                txtCarId.Text = car.CarId.ToString();
                txtCarName.Text = car.CarName;
                txtType.Text = car.Type;
                cbStatus.ItemsSource = con.CarStatuses.ToList();
                cbStatus.SelectedIndex = car.CarStatusId - 1;
                txtColor.Text = car.Color;
                txtFuel.Text = car.Fuel;
                txtBrand.Text = car.Brand;
                dpDateCar.SelectedDate = car.DateCar;
                txtPrice.Text = car.Price.ToString();
                txtNumberOfSeats.Text = car.NumberOfSeats.ToString();
                txtRentalPrice.Text = car.RentalPrice.ToString();
                popupEdit.IsOpen = true;
            }
            else
            {
                MessageBox.Show("Can't not find car neeed to edit!!!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = (Car)con.Cars.Include(x => x.CarStatus).FirstOrDefault(c => c.CarId == Convert.ToInt32(txtCarId.Text));
                car.CarId = Convert.ToInt32(txtCarId.Text);
                car.CarStatusId = (cbStatus.SelectedItem as CarStatus).CarStatusId;
                car.Color = txtColor.Text;
                car.Fuel = txtFuel.Text;
                car.Brand = txtBrand.Text;
                car.DateCar = dpDateCar.SelectedDate;
                car.Price = Decimal.TryParse(txtPrice.Text, out decimal price) ? price : 0; // Parse Price
                car.NumberOfSeats = int.TryParse(txtNumberOfSeats.Text, out int numberOfSeats) ? numberOfSeats : 0; // Parse NumberOfSeats
                car.RentalPrice = Decimal.TryParse(txtRentalPrice.Text, out decimal rentalPrice) ? rentalPrice : 0; // Parse RentalPrice
                car.CarName = txtCarName.Text;
                car.Type = txtType.Text;
                con.Cars.Update(car);
                con.SaveChanges();
                popupEdit.IsOpen = false;
                MessageBox.Show("Update successfully!!!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                loadCar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update unsuccessfully!!!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            popupEdit.IsOpen = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            popupCreate.IsOpen = true;
        }
    }
}

