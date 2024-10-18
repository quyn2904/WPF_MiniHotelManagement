using BusinessObjects;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly CustomerService _customerService;
        public LoginWindow()
        {
            InitializeComponent();
            this._customerService = CustomerService.GetInstance();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPass.Password;
            if (_customerService.AdminLogin(email, password)) {
                this.Hide();
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if (_customerService.CustomerLogin(email, password) != null)
            {
                this.Hide();
                CustomerWindow customerWindow = new CustomerWindow(_customerService.CustomerLogin(email, password));
                customerWindow.Show();
            }
            else
            {
                MessageBox.Show("You are not permission");
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
