using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using Testovaya.Model;

namespace Testovaya
{
    /// <summary>
    /// Логика взаимодействия для newSotrudnik.xaml
    /// </summary>
    public partial class newSotrudnik : Window
    {
        private Sotrudnikii _currentsotr = new Sotrudnikii(); //Переменная с инфой о таблице и проверка
        public newSotrudnik(Sotrudnikii selectedSotr)
        {
            InitializeComponent();
            AppData.db.Sotrudnikii.ToList();
            if(selectedSotr != null)
            { 
                _currentsotr = selectedSotr;
                //Date = DateTime.Now;
            }
            else
            {
                _currentsotr.Date = DateTime.Now;
            }
            DataContext = _currentsotr;

        }

        private void FullName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Date_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dolzh_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Save2_Btn_Click(object sender, RoutedEventArgs e)//Проверки на то всё ли вписано и сохранения
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentsotr.FullName))
                errors.AppendLine("Введите ФИО");

            if (_currentsotr.Date == null)
                errors.AppendLine("Введите дату");

            if (string.IsNullOrWhiteSpace(_currentsotr.Dolzhnost))
                errors.AppendLine("Введите Должность");

            if (string.IsNullOrWhiteSpace(_currentsotr.Family))
                errors.AppendLine("Введите Семейное положение");

            if (string.IsNullOrWhiteSpace(_currentsotr.Adress))
                errors.AppendLine("Введите Адрес");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentsotr.Id >= 0)
                PenisEntities.GetContext().Sotrudnikii.AddOrUpdate(_currentsotr);

            try
            {
                PenisEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Sotrudniki sotrudniki = new Sotrudniki();
                sotrudniki.Show();
                Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        
    }
}
