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
    /// Логика взаимодействия для Raspisanye.xaml
    /// </summary>
    public partial class Raspisanye : Window
    {
        public Raspisanye() //Разграничение с обращением к Globals объявленным в MainWindow
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
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            Sotrudniki sotrudniki = new Sotrudniki();
            sotrudniki.Show();
            this.Close();
        }
    }
}
