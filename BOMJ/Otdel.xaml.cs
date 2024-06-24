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
    /// Логика взаимодействия для Otdel.xaml
    /// </summary>
    public partial class Otdel : Window
    {
       

        public Otdel()
        {
            InitializeComponent();
            using (SpravkaContext db = new SpravkaContext())
            {

                List<string> filtertList = db.Otdels.Select(u => u.Name).Distinct().ToList();
                filtertList.Insert(0, "Все отдлелы");
                filterUserComboBox.ItemsSource = filtertList.ToList();
                productlistView.ItemsSource = db.Otdels.ToList();

            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void filterUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }
        private void UpdateProducts()
        {
            using (SpravkaContext db = new SpravkaContext())
            {
                var currentProducts = db.Otdels.ToList();
                productlistView.ItemsSource = currentProducts;

                //Фильтрация

                if (filterUserComboBox.SelectedIndex != -1)
                {
                    if (db.Otdels.Select(u => u.Name).Distinct().ToList().Contains(filterUserComboBox.SelectedValue))
                    {
                        currentProducts = currentProducts.Where(u => u.Name == filterUserComboBox.SelectedValue.ToString()).ToList();
                    }
                    else
                    {
                        currentProducts = currentProducts.ToList();
                    }
                }
                //Поиск
                if (searchBox.Text.Length > 0)
                {

                    currentProducts = currentProducts.Where(u => u.Name.Contains(searchBox.Text) || u.Boss.Contains(searchBox.Text)).ToList();

                }

                productlistView.ItemsSource = currentProducts;
            }
        }

        //Строка поиска
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AddSotrudWindow().ShowDialog();
        }


    }
}
