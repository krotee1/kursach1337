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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Testovaya.Model;

namespace Testovaya
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Window
    {
        public WelcomePage()
        {
            InitializeComponent();
            

            if (MainWindow.Globals.UserRole == 1) //Проверка на разграничение
            {
                Btn_Del.Visibility = Visibility.Visible;
                skritoe.Visibility = Visibility.Visible;
            }
            else
            {
                Btn_Del.Visibility = Visibility.Collapsed;
                skritoe.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.User.ToList();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            NewUser newuser = new NewUser();
            newuser.Show();
            this.Close();
        }


        private void RemoveBtn_Click(object sender, RoutedEventArgs e)//Кнопка удаления, с предупреждением
        {
            if (MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentUser = UsersGrid.SelectedItem as User;
                AppData.db.User.Remove(CurrentUser);
                AppData.db.SaveChanges();
                
                UsersGrid.ItemsSource = AppData.db.User.ToList();
                MessageBox.Show("Всё удалено");
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
            Sotrudniki sotrudniki = new Sotrudniki();
            sotrudniki.Show();
            this.Close();
        }

        private void Raspis_Click(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            Raspisanye raspisanye = new Raspisanye();
            raspisanye.Show();
            this.Close();
        }

        private void skritoe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
