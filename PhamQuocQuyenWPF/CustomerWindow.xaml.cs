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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private Customer customer;
        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private readonly BookingReservationService _bookingReservationService = BookingReservationService.GetInstance();
        private readonly CustomerService _customerService = CustomerService.GetInstance();

        public void LoadBookingReservations()
        {
            var bookingReservations = _bookingReservationService.GetBookingReservations(this.customer.CustomerId);
            dgData.ItemsSource = bookingReservations;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerInfo();
            LoadBookingReservations();
        }

        public void LoadCustomerInfo()
        {
            txtFullName.Text = this.customer.CustomerFullName;
            txtEmail.Text = this.customer.EmailAddress;
            txtPassword.Password = this.customer.Password;
            txtTelephone.Text = this.customer.Telephone;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.customer.CustomerFullName = txtFullName.Text;
            this.customer.Password = txtPassword.Password;
            this.customer.Telephone = txtTelephone.Text;
            _customerService.UpdateCustomer(this.customer);
            MessageBox.Show("Update successfully!");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
