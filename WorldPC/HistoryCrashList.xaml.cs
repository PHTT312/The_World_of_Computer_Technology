using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для HistoryCrashList.xaml
    /// </summary>
    public partial class HistoryCrashList : Window
    {
        public WorldPCEntities _context = new WorldPCEntities();
        public List<history_list> history_lists = new List<history_list>();
        public static string transferFullName;
        public static int transferId;
        public HistoryCrashList(string fullName, int id)
        {
            InitializeComponent();
            transferFullName = fullName;
            transferId = id;
            fullNamelbl.Content = fullName;
            var historyList = _context.history_list
            .Select(s => new
            {
                s.id,
                s.date_crash,
                s.date_repair,
                s.reason,
                name = s.crash_history.computer_equipment.model.name,
            })
            .ToList();
            HistoryCrashDataGrid.ItemsSource = historyList;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            CollectorMenu collectorMenu = new CollectorMenu(transferFullName, transferId);
            collectorMenu.Show();
            this.Hide();
        }

        private void HistoryCrashDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    if (HistoryCrashDataGrid.SelectedItem != null)
                    {
                        var selectedRow = (DataGridRow)HistoryCrashDataGrid.ItemContainerGenerator.ContainerFromIndex(HistoryCrashDataGrid.SelectedIndex);
                        var datePicker = FindVisualChild<DatePicker>(selectedRow);

                        if (datePicker != null)
                        {
                            var selectedDate = datePicker.SelectedDate;

                            var selectedIndex = HistoryCrashDataGrid.SelectedIndex;
                            List<history_list> history_Lists = new List<history_list>();
                            history_Lists = _context.history_list.ToList();

                            if (history_Lists[selectedIndex] != null)
                            {
                                history_Lists[selectedIndex].date_repair = selectedDate;
                                _context.SaveChanges();
                                var historyList = _context.history_list
                                .Select(s => new
                                {
                                    s.id,
                                    s.date_crash,
                                    s.date_repair,
                                    s.reason,
                                    name = s.crash_history.computer_equipment.model.name,
                                })
                                .ToList();
                                HistoryCrashDataGrid.ItemsSource = historyList;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите сбой!");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T result)
                {
                    return result;
                }
                else
                {
                    var descendant = FindVisualChild<T>(child);
                    if (descendant != null)
                    {
                        return descendant;
                    }
                }
            }
            return null;
        }
    }
}
