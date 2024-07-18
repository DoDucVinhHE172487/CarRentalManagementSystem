using BusinessObjects.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;

namespace CarRentalManagementSystem
{
    /// <summary>
    /// Interaction logic for ManageCustomer.xaml
    /// </summary>
    public partial class ManageCustomer : Window
    {
        CarRentalManagementSystemContext con;
        public ManageCustomer()
        {
            InitializeComponent();
            con = new CarRentalManagementSystemContext();
            loadCustomer();
        }
        public void loadCustomer()
        {
            lvCustomer.ItemsSource = con.Customers.ToList();
        }
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            popupCreateCustomer.IsOpen = true;
        }
        private void CancelCustomerButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (popupCreateCustomer.IsOpen)
            {
                popupCreateCustomer.IsOpen = false;
            }
        }
        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Customer customer)
            {
                txtCustomerId.Text = customer.CustomerId.ToString();
                txtCustomerName.Text = customer.CustomerName;
                txtPhoneNumber.Text = customer.PhoneNumber;
                txtAddress.Text = customer.Address;
                popupEditCustomer.IsOpen = true;
            }
            else
            {
                MessageBox.Show("Cannot find Customer to edit", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SaveCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCustomerInput(isCreate: false))
            {
                try
                {
                    Customer customer = con.Customers.FirstOrDefault(c => c.CustomerId == Convert.ToInt32(txtCustomerId.Text));
                    if (customer != null)
                    {
                        if (IsPhoneNumberDuplicate(customer.PhoneNumber, customer.CustomerId))
                        {
                            MessageBox.Show("Phone number already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        customer.CustomerName = txtCustomerName.Text;
                        customer.PhoneNumber = txtPhoneNumber.Text;
                        customer.Address = txtAddress.Text;
                        con.Customers.Update(customer);
                        con.SaveChanges();
                        popupEditCustomer.IsOpen = false;
                        MessageBox.Show("Customer updated successfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        loadCustomer();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void CancelCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (popupEditCustomer.IsOpen)
            {
                popupEditCustomer.IsOpen = false;
            }
        }
        private void CustomerButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCustomerInput(isCreate: true))
            {
                try
                {
                    string phoneNumber = txtPhoneNumberCreate.Text;

                    if (IsPhoneNumberDuplicate(phoneNumber))
                    {
                        MessageBox.Show("Phone number already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    Customer newCustomer = new Customer
                    {
                        CustomerName = txtCustomerNameCreate.Text,
                        PhoneNumber = txtPhoneNumberCreate.Text,
                        Address = txtAddressCreate.Text
                    };

                    con.Customers.Add(newCustomer);
                    con.SaveChanges();
                    popupCreateCustomer.IsOpen = false;
                    MessageBox.Show("Customer created successfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    loadCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Creation failed: " + ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ValidateCustomerInput(bool isCreate)
        {
            string customerName, phoneNumber, address;

            if (isCreate)
            {
                customerName = txtCustomerNameCreate.Text;
                phoneNumber = txtPhoneNumberCreate.Text;
                address = txtAddressCreate.Text;
            }
            else
            {
                customerName = txtCustomerName.Text;
                phoneNumber = txtPhoneNumber.Text;
                address = txtAddress.Text;
            }

            if (string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show("Customer Name is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Phone Number is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!Regex.IsMatch(phoneNumber, @"^0\d{9}$"))
            {
                MessageBox.Show("Phone Number must be exactly 10 digits and start with '0'", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        private bool IsPhoneNumberDuplicate(string phoneNumber, int? customerId = null)
        {
            if (customerId.HasValue)
            {
                return con.Customers.Any(c => c.PhoneNumber == phoneNumber && c.CustomerId != customerId.Value);
            }
            else
            {
                return con.Customers.Any(c => c.PhoneNumber == phoneNumber);
            }
        }
    }
}
