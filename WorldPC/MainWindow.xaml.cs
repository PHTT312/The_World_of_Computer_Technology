using System;
using System.Linq;
using System.Windows;
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            using (var _context = new WorldPCEntities())
            {
                if (Login.Text == "" && Password.Password == "")
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    var info = _context.info.FirstOrDefault(x => x.login == Login.Text && x.password == Password.Password);

                    if (info != null)
                    {
                        var staff = _context.staff.FirstOrDefault(x => x.info_id == info.id); // Получить сотрудника
                        var post = _context.post.FirstOrDefault(x => x.id == staff.post_id); // Получить сотрудника

                        string postName = post.name; // Получить название должности
                        string fullName = $"{staff.surname} " + $" {staff.name} " + $" {staff.patronymic}"; // Получить ФИО сотрудника
                        int idStaff = Convert.ToInt32(staff.post_id);

                        MessageBox.Show($"Вы успешно вошли под ролью {postName}. Сотрудник: {fullName}");

                        switch (staff.post_id)
                        {
                            case 1:
                                CollectorMenu collectorMenu = new CollectorMenu(fullName, idStaff);
                                collectorMenu.Show();
                                this.Hide();
                                break;
                            case 2:
                                ManagerMenu managerMenu = new ManagerMenu(fullName);
                                managerMenu.Show();
                                this.Hide();
                                break;
                            case 3:
                                DirectorMenu directorMenu = new DirectorMenu(fullName);
                                directorMenu.Show();
                                this.Hide();
                                break;
                        }                        
                    }
                }
            }
        }

        private void WorkWithClientBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientMenu clientMenu = new ClientMenu();
            clientMenu.Show();
            this.Hide();
        }
    }
}
