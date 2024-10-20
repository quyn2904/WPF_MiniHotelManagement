﻿using System;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagementWindow customerManagementWindow = new CustomerManagementWindow();
            customerManagementWindow.ShowDialog();
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomManagementWindow roomManagementWindow = new RoomManagementWindow();
            roomManagementWindow.ShowDialog();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            BookingManagementWindow bookingManagementWindow = new BookingManagementWindow();
            bookingManagementWindow.ShowDialog();
        }
    }
}
