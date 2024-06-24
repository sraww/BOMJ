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
    /// Логика взаимодействия для Guest.xaml
    /// </summary>
    /// 
    public partial class Guest : Window
    {
        public Guest()
        {
            //Инициализация компонентов
            InitializeComponent();
            using (SpravkaContext db = new SpravkaContext())
            {
                List<string> sortList = new List<string>() { "По возрастанию ЗП", "По убыванию ЗП" };
                sortUserComboBox.ItemsSource = sortList.ToList();

                productlistView.ItemsSource = db.Sotruds.ToList();

                countProducts.Text = $"Количество: {db.Sotruds.Count()}";


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void sortUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }
        private void UpdateProducts()
        {
            using (SpravkaContext db = new SpravkaContext())
            {

                var currentProducts = db.Sotruds.ToList();
                productlistView.ItemsSource = currentProducts;
                countProducts.Text = $"Количество: {currentProducts.Count} из {db.Sotruds.ToList().Count}";

                //Сортировка
                if (sortUserComboBox.SelectedIndex != -1)
                {
                    if (sortUserComboBox.SelectedValue == "По убыванию ЗП")
                    {
                        currentProducts = currentProducts.OrderByDescending(u => u.Money).ToList();

                    }

                    if (sortUserComboBox.SelectedValue == "По возрастанию Зп")
                    {
                        currentProducts = currentProducts.OrderBy(u => u.Money).ToList();

                    }
                }
                //Поиск
                if (searchBox.Text.Length > 0)
                {

                    currentProducts = currentProducts.Where(u => u.Name.Contains(searchBox.Text) || u.Surname.Contains(searchBox.Text)).ToList();

                }

                productlistView.ItemsSource = currentProducts;
            }
        }

        private void сlearButton_Click(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
            sortUserComboBox.SelectedIndex = -1;
        }
    }
}
