using BOMJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        //Инициализация  в форме Login
        public Login()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Использование контекста данных
            using (SpravkaContext db = new SpravkaContext())
            {
                User user = db.Users.Where(u => u.Login == loginBox.Text && u.Password == passwordBox.Password).FirstOrDefault() as User;

                // admin
                //Авторизация 
                if (user != null)
                {
                    
                    new Admin(user).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неуспешная авторизация");
             
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Guest().Show();
            //this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
        
}

