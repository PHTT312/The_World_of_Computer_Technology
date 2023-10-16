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
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для EquipmentList.xaml
    /// </summary>
    public partial class EquipmentList : Window
    {
        public WorldPCEntities _context = new WorldPCEntities();
        public static string transferFullName;
        public EquipmentList(string fullName)
        {
            InitializeComponent();
            transferFullName = fullName;
            directorFullNamelbl.Content = fullName;
            var computerEquipList = _context.computer_equipment
            .Select(s => new
            {
                s.id,
                model = s.model.name,
                typeName = s.model.type.name,
                s.characteristic
            })
            .ToList();
            computerList.ItemsSource = computerEquipList;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectorMenu directorMenu = new DirectorMenu(transferFullName);
            directorMenu.Show();
            this.Hide();
        }
    }
}
