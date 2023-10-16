using System;
using System.Linq;
using System.Windows;
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для ClientMenu.xaml
    /// </summary>
    public partial class ClientMenu : Window
    {
        public WorldPCEntities _context = new WorldPCEntities();
        public ClientMenu()
        {
            InitializeComponent();
            var genders = _context.gender.ToList();
            genderList.ItemsSource = genders;
            genderList.DisplayMemberPath = "name";
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (surnameTb.Text == "" || nameTb.Text == "" || patronymicTb.Text == "" || serialTb.Text == "" || numberTb.Text == "" || phoneTb.Text == "" || adressTb.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var newClient = new client
                    {
                        surname = surnameTb.Text,
                        name = nameTb.Text,
                        patronymic = patronymicTb.Text,
                        phone = phoneTb.Text,
                        adress = adressTb.Text,
                        passport_serial = serialTb.Text,
                        passport_number = numberTb.Text,
                        gender_id = genderList.SelectedIndex + 1,
                    };
                    _context.client.Add(newClient);
                    _context.SaveChanges();
                    int clientId = newClient.id;

                    OrderOnRepair orderOnRepair = new OrderOnRepair(clientId);
                    orderOnRepair.Show();
                }
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
