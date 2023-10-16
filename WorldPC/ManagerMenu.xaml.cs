using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для ManagerMenu.xaml
    /// </summary>
    public partial class ManagerMenu : Window
    {
        public WorldPCEntities _context = new WorldPCEntities();
        public static string transerFullName;
        public static List<staff> staffsSurname = new List<staff>();
        public ManagerMenu(string fullName)
        {
            InitializeComponent();
            transerFullName = fullName;
            managerFullNamelbl.Content = fullName;
            var collectors = _context.staff.Where(s => s.post_id == 1).Select(s => new { FullName = s.surname + " " + s.name + " " + s.patronymic }).ToList();
            staffsSurname = _context.staff.Where(s => s.post_id == 1).ToList();
            listCollectors.ItemsSource = collectors;
            listCollectors.DisplayMemberPath = "FullName";
            var statuses = _context.status.Where(x => x.id != 1).ToList();
            listStatuses.ItemsSource = statuses;
            listStatuses.DisplayMemberPath = "name";
            var orderList = _context.repair_order.
            Select(s => new
            {
                s.id,
                s.delivery_date,
                clientFullName = s.client.surname + " " + s.client.name + " " + s.client.patronymic,
                s.describe,
                staffFullName = s.staff.surname + " " + s.staff.name + " " + s.staff.patronymic,
                model = s.computer_equipment.model.name,
                status = s.status.name
            }).ToList();
            orderRepairList.ItemsSource = orderList;
        }

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = orderRepairList.SelectedIndex;
                List<repair_order> repair_Orders = new List<repair_order>();
                repair_Orders = _context.repair_order.ToList();
                repair_order selectedOrder = repair_Orders[selectedIndex];

                selectedOrder.staff_id = staffsSurname[listCollectors.SelectedIndex].id;
                selectedOrder.status_id = listStatuses.SelectedIndex + 2;
                _context.SaveChanges();
                MessageBox.Show("Заказ успешно обновлён!");
                var orderList = _context.repair_order.
                Select(s => new
                {
                    s.id,
                    s.delivery_date,
                    clientFullName = s.client.surname + " " + s.client.name + " " + s.client.patronymic,
                    s.describe,
                    staffFullName = s.staff.surname + " " + s.staff.name + " " + s.staff.patronymic,
                    model = s.computer_equipment.model.name,
                    status = s.status.name
                }).ToList();
                orderRepairList.ItemsSource = orderList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = orderRepairList.SelectedIndex;
                List<repair_order> repair_Orders = new List<repair_order>();
                repair_Orders = _context.repair_order.ToList();
                repair_order selectedOrder = repair_Orders[selectedIndex];
                var order = _context.repair_order.Find(selectedOrder.id);
                _context.repair_order.Remove(order);
                _context.SaveChanges();
                MessageBox.Show("Заказ успешно удалён!");
                var orderList = _context.repair_order.
                Select(s => new
                {
                    s.id,
                    s.delivery_date,
                    clientFullName = s.client.surname + " " + s.client.name + " " + s.client.patronymic,
                    s.describe,
                    staffFullName = s.staff.surname + " " + s.staff.name + " " + s.staff.patronymic,
                    model = s.computer_equipment.model.name,
                    status = s.status.name
                }).ToList();
                orderRepairList.ItemsSource = orderList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
