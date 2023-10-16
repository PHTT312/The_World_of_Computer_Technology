using System;
using System.Windows;
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для CrashMenu.xaml
    /// </summary>
    public partial class CrashMenu : Window
    {
        public static int idHistoryForAddHistoryList;
        public WorldPCEntities _context = new WorldPCEntities();
        public CrashMenu(string fullName, int idHistory)
        {
            InitializeComponent();
            idHistoryForAddHistoryList = idHistory;
        }

        private void SaveHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var historylist = new history_list
                {
                    date_crash = Convert.ToDateTime(dateCrash.Text),
                    date_repair = null,
                    reason = reasonTb.Text,
                    crash_history_id = idHistoryForAddHistoryList
                };
                _context.history_list.Add(historylist);
                _context.SaveChanges();
                MessageBox.Show("Сбой успешно записано!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
