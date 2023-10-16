using Microsoft.Win32;
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
    /// Логика взаимодействия для StaffAdd.xaml
    /// </summary>
    public partial class StaffAdd : Window
    {
        public WorldPCEntities _context = new WorldPCEntities();
        public static string transferFullName;
        public static string pathPhotoStaff;
        public StaffAdd(string fullName)
        {
            InitializeComponent();
            transferFullName = fullName;
            directorFullNamelbl.Content = fullName;
            var posts = _context.post.ToList();
            postList.ItemsSource = posts;
            postList.DisplayMemberPath = "name";
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (surnameTb.Text == "" || nameTb.Text == "" || patronymicTb.Text == "" || loginTb.Text == "" || passwordTb.Text == "" || photoStaff.Source == null || postList.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    var newInfo = new info
                    {
                        login = loginTb.Text,
                        password = passwordTb.Text
                    };
                    _context.info.Add(newInfo);
                    int idInfo = newInfo.id;
                    var newStaff = new staff
                    {
                        surname = surnameTb.Text,
                        name = nameTb.Text,
                        patronymic = patronymicTb.Text,
                        info_id = idInfo,
                        post_id = postList.SelectedIndex + 1,
                        photo = pathPhotoStaff
                    };
                    _context.staff.Add(newStaff);
                    _context.SaveChanges();
                    MessageBox.Show("Сотрудник успешно добавлен!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Изображения (*.png;*.jpg)|*.png;*.jpg|Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    pathPhotoStaff = openFileDialog.FileName; // Сохраняем путь к выбранной картинке
                    BitmapImage bitmap = new BitmapImage(new Uri(pathPhotoStaff));
                    photoStaff.Source = bitmap; // Отображаем выбранную картинку в элементе Image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectorMenu directorMenu = new DirectorMenu(transferFullName);
            directorMenu.Show();
            this.Hide();
        }
    }
}
