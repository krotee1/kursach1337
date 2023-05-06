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

namespace Testovaya
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings() //Разграничение прав Админ или Пользователь
        {
            InitializeComponent();
            

            if (MainWindow.Globals.UserRole == 1)
            {
                skritoe.Visibility = Visibility.Visible;
            }
            else
            {
                skritoe.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            Sotrudniki sotrudniki = new Sotrudniki();
            sotrudniki.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            Raspisanye raspisanye = new Raspisanye();
            raspisanye.Show();
            this.Close();
        }
    }
}
