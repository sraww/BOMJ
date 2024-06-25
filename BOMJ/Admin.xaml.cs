using BOMJ.Models;
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

namespace BOMJ
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
       
        public Admin(User user)
        {
            InitializeComponent();

            //Использование бд
            using (SpravkaContext db = new SpravkaContext())
            {
                if (user != null)
                {
                    statusUser.Text = Convert.ToString(user.Surname);
                    statusUser_1.Text = Convert.ToString(user.Name);
                    MessageBox.Show($"Добро пожаловать: {user.Surname} {user.Name}. \r\t");
                }
                else
                {
                    statusUser.Text = "Гость";
                    MessageBox.Show("Гость");
                }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
        // Сортировка пользователей
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Sotr().Show();
            this.Close();
        }

        // Окно отделов
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Otdel().Show();
            this.Close();
        }
    }
}

