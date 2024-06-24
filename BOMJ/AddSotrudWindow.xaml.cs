using BOMJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BOMJ
{
    /// <summary>
    /// Логика взаимодействия для AddSotrudWindow.xaml
    /// </summary>
    public partial class AddSotrudWindow : Window
    {
        public AddSotrudWindow()
        {
            InitializeComponent();
            StringBuilder errors = new StringBuilder();
           
            if (string.IsNullOrWhiteSpace(nameBox.Text))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(SurnameBox.Text))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(MoneyBox.Text))
                errors.AppendLine("Укажите заработную плату");
            if (string.IsNullOrWhiteSpace(StajBox.Text))
                errors.AppendLine("Укажите стаж");
            if (string.IsNullOrWhiteSpace(OtdelBox.Text))
                errors.AppendLine("Укажите номер отдела");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
        }

        private void saveProductButtonClick(object sender, RoutedEventArgs e)
        {
            using (SpravkaContext db = new SpravkaContext())
            {

                try
                {
                    Sotrud sotrud = new Sotrud()
                    {

                        
                        Name = nameBox.Text,
                        Surname = SurnameBox.Text,
                        Staj = Convert.ToInt32( StajBox.Text),
                        Money = Convert.ToInt32(MoneyBox.Text),
                        Idotdel = Convert.ToInt32(OtdelBox.Text),
                        


                    };


                    if (sotrud.Money <= 0)
                    {
                        MessageBox.Show("Зарпалата должна быть положительной!");
                        return;
                    }

                    if (sotrud.Idotdel < 0)
                    {
                        MessageBox.Show("Номер не может быть меньше нуля!");
                        return;
                    }
                    if (sotrud.Staj < 0)
                    {
                        MessageBox.Show("Стаж не может быть меньше нуля!");
                        return;
                    }

                    db.Sotruds.Add(sotrud);

                    

                    db.SaveChanges();

                    MessageBox.Show("Сотрудник успешно добавлен!");

                   

                }
                catch (Exception ex)
                {
                   
                }


            }
            this.Close();
        }

    }

}
