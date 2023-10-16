using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для DirectorMenu.xaml
    /// </summary>
    public partial class DirectorMenu : Window
    {
        public static string transferFullName;
        public DirectorMenu(string fullName)
        {
            InitializeComponent();
            transferFullName = fullName;
            directorFullNamelbl.Content = fullName;
        }

        private void StaffListBtn_Click(object sender, RoutedEventArgs e)
        {
            StaffList staffList = new StaffList(transferFullName);
            staffList.Show();
            this.Hide();
        }

        private void StaffAddBtn_Click(object sender, RoutedEventArgs e)
        {
            StaffAdd staffAdd = new StaffAdd(transferFullName); 
            staffAdd.Show();
            this.Hide();
        }

        private void EquipmentListBtn_Click(object sender, RoutedEventArgs e)
        {
            EquipmentList equipmentList = new EquipmentList(transferFullName);
            equipmentList.Show();
            this.Hide();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
