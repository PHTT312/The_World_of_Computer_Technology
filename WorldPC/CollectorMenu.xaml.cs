using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для CollectorMenu.xaml
    /// </summary>
    public partial class CollectorMenu : Window
    {
        public WorldPCEntities _context = new WorldPCEntities();
        public static int idStaffForAdd;
        public static string transferfullName;
        public static int historyId;
        public CollectorMenu(string fullName, int idStaff)
        {
            InitializeComponent();
            fullNamelbl.Content = fullName;
            idStaffForAdd = idStaff;
            var computerEquipList = _context.computer_equipment
            .Select(s => new
            {
                s.id,
                s.model.name,
                typeName = s.model.type.name,
                s.characteristic
            })
            .ToList();
            computerList.ItemsSource = computerEquipList;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void computerList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int selectedIndex = computerList.SelectedIndex;
                List<computer_equipment> listok = new List<computer_equipment>();
                listok = _context.computer_equipment.ToList();
                var history = new crash_history
                {
                    computer_equipment_id = listok[selectedIndex].id,
                    staff_id = idStaffForAdd
                };
                _context.crash_history.Add(history);
                _context.SaveChanges();
                historyId = history.id;
                CrashMenu crashMenu = new CrashMenu(transferfullName, history.id);
                crashMenu.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void HistoryOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            HistoryCrashList historyCrashList = new HistoryCrashList(transferfullName, historyId);
            historyCrashList.Show();
            this.Hide();
        }
    }
}
