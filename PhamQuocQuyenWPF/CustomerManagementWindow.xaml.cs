using BusinessObjects;
using Services;
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

namespace PhamQuocQuyenWPF
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        public CustomerManagementWindow()
        {
            InitializeComponent();
        }
        private Customer customer;

        private readonly CustomerService _customerService = CustomerService.GetInstance();

        public void LoadCustomerInformation()
        {
            var customerInformations = _customerService.GetAllCustomer();
            dgData.ItemsSource = customerInformations;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerInformation();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.customer.CustomerFullName = txtFullName.Text;
            this.customer.Password = txtPassword.Password;
            this.customer.EmailAddress = txtEmail.Text;
            this.customer.Telephone = txtTelephone.Text;
            _customerService.UpdateCustomer(this.customer);
            MessageBox.Show("Update success");
            ResetInput();
            LoadCustomerInformation();
            this.customer = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Customer cus = new Customer();
            cus.EmailAddress = txtEmail.Text;
            cus.CustomerFullName = txtFullName.Text;
            cus.Password = txtPassword.Password;
            cus.Telephone = txtTelephone.Text;
            _customerService.AddCustomer(cus);
            MessageBox.Show("Add success");
            ResetInput();
            LoadCustomerInformation();
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Customer selectedCustomer)
            {
                this.customer = selectedCustomer;
                txtEmail.Text = selectedCustomer.EmailAddress;
                txtFullName.Text = selectedCustomer.CustomerFullName;
                txtPassword.Password = selectedCustomer.Password;
                txtTelephone.Text = selectedCustomer.Telephone;
            }
        }

        private void ResetInput()
        {
            txtEmail.Text = "";
            txtFullName.Text = "";
            txtPassword.Password = "";
            txtTelephone.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.customer == null)
            {
                MessageBox.Show("Please select a customer to delete");
                return;
            }
            _customerService.DeleteCustomer(this.customer);
            MessageBox.Show("Delete Successfully");
            ResetInput();
            LoadCustomerInformation();
        }
    }
}
