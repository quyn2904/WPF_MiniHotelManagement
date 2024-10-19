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
    /// Interaction logic for RoomManagementWindow.xaml
    /// </summary>
    public partial class RoomManagementWindow : Window
    {
        public RoomManagementWindow()
        {
            InitializeComponent();
        }
        private RoomInformation roomInformation;

        private readonly RoomInformationService _roomInformationService = RoomInformationService.GetInstance();

        public void LoadRoomInformation()
        {
            var roomInformations = _roomInformationService.GetAllRooms();
            dgData.ItemsSource = roomInformations;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoomInformation();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.roomInformation.RoomDetailDescription = txtDescription.Text;
            this.roomInformation.RoomNumber = txtRoomNumber.Text;
            this.roomInformation.RoomPricePerDay = decimal.Parse(txtPrice.Text);
            this.roomInformation.RoomMaxCapacity = short.Parse(txtCapacity.Text);
            _roomInformationService.UpdateRoom(this.roomInformation);
            MessageBox.Show("Update success");
            ResetInput();
            LoadRoomInformation();
            this.roomInformation = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            RoomInformation room = new RoomInformation();
            room.RoomNumber = txtRoomNumber.Text;
            room.RoomDetailDescription = txtDescription.Text;
            room.RoomPricePerDay = decimal.Parse(txtPrice.Text);
            room.RoomMaxCapacity = short.Parse(txtCapacity.Text);
            _roomInformationService.AddNewRoom(room);
            MessageBox.Show("Add success");
            ResetInput();
            LoadRoomInformation();
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is RoomInformation selectedRoom)
            {
                this.roomInformation = selectedRoom;
                txtRoomNumber.Text = selectedRoom.RoomNumber;
                txtDescription.Text = selectedRoom.RoomDetailDescription;
                txtPrice.Text = selectedRoom.RoomPricePerDay.ToString();
                txtCapacity.Text = selectedRoom.RoomMaxCapacity.ToString();
            }
        }

        private void ResetInput()
        {
            txtRoomNumber.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtCapacity.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.roomInformation == null)
            {
                MessageBox.Show("Please select a room to delete");
                return;
            }
            _roomInformationService.DeleteRoom(this.roomInformation);
            MessageBox.Show("Delete Successfully");
            ResetInput();
            LoadRoomInformation();
        }
    }
}
