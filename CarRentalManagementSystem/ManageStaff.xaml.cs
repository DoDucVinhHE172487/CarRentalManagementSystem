﻿using BusinessObjects.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace CarRentalManagementSystem
{
    /// <summary>
    /// Interaction logic for ManageStaff.xaml
    /// </summary>
    public partial class ManageStaff : Window
    {
        CarRentalManagementSystemContext con;
        public ManageStaff()
        {
            InitializeComponent();
            con = new CarRentalManagementSystemContext();
            LoadStaff();
        }

        public void LoadStaff()
        {
            lvStaff.ItemsSource = con.Staff.ToList();
        }

        private void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            popupCreateStaff.IsOpen = true;
        }

        private void CancelStaffButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (popupCreateStaff.IsOpen)
            {
                popupCreateStaff.IsOpen = false;
            }
        }

        private void btnEditStaff_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Staff staff)
            {
                txtStaffId.Text = staff.StaffId.ToString();
                txtStaffName.Text = staff.StaffName;
                txtPhoneNumber.Text = staff.PhoneNumber;
                txtEmail.Text = staff.Email;
                txtAddress.Text = staff.Address;
                txtSalary.Text = staff.Salary.ToString();
                popupEditStaff.IsOpen = true;
            }
            else
            {
                MessageBox.Show("Cannot find Staff to edit", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveStaffButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateStaffInput(isCreate: false))
            {
                try
                {
                    Staff staff = con.Staff.FirstOrDefault(s => s.StaffId == Convert.ToInt32(txtStaffId.Text));
                    if (staff != null)
                    {
                        staff.StaffName = txtStaffName.Text;
                        staff.PhoneNumber = txtPhoneNumber.Text;
                        staff.Email = txtEmail.Text;
                        staff.Address = txtAddress.Text;
                        staff.Salary = decimal.Parse(txtSalary.Text);

                        if (IsEmailDuplicate(staff.Email, staff.StaffId))
                        {
                            MessageBox.Show("Email already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        con.Staff.Update(staff);
                        con.SaveChanges();
                        popupEditStaff.IsOpen = false;
                        MessageBox.Show("Staff updated successfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadStaff();
                    }
                    else
                    {
                        MessageBox.Show("Staff not found", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CancelStaffButton_Click(object sender, RoutedEventArgs e)
        {
            if (popupEditStaff.IsOpen)
            {
                popupEditStaff.IsOpen = false;
            }
        }

        private void StaffButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateStaffInput(isCreate: true))
            {
                try
                {
                    string email = txtEmailCreate.Text;

                    if (IsEmailDuplicate(email))
                    {
                        MessageBox.Show("Email already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    Staff newStaff = new Staff
                    {
                        StaffName = txtStaffNameCreate.Text,
                        PhoneNumber = txtPhoneNumberCreate.Text,
                        Email = email,
                        Address = txtAddressCreate.Text,
                        Salary = decimal.Parse(txtSalaryCreate.Text)
                    };

                    con.Staff.Add(newStaff);
                    con.SaveChanges();
                    popupCreateStaff.IsOpen = false;
                    MessageBox.Show("Staff created successfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadStaff();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Creation failed: " + ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ValidateStaffInput(bool isCreate)
        {
            string staffName, phoneNumber, email, address, salary;

            if (isCreate)
            {
                staffName = txtStaffNameCreate.Text;
                phoneNumber = txtPhoneNumberCreate.Text;
                email = txtEmailCreate.Text;
                address = txtAddressCreate.Text;
                salary = txtSalaryCreate.Text;
            }
            else
            {
                staffName = txtStaffName.Text;
                phoneNumber = txtPhoneNumber.Text;
                email = txtEmail.Text;
                address = txtAddress.Text;
                salary = txtSalary.Text;
            }

            if (string.IsNullOrWhiteSpace(staffName))
            {
                MessageBox.Show("Staff Name is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email is not in a valid format", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(salary) || !decimal.TryParse(salary, out _))
            {
                MessageBox.Show("Salary is required and must be a valid number", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new MailAddress(trimmedEmail);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private bool IsEmailDuplicate(string email, int? staffId = null)
        {
            if (staffId.HasValue)
            {
                return con.Staff.Any(s => s.Email == email && s.StaffId != staffId.Value);
            }
            return con.Staff.Any(s => s.Email == email);
        }
    }
}