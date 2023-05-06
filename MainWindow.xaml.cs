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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TxbPassword.IsEnabled = false;
        }

        public static class Globals //Глобальные переменные для разграничения 
        {
            public static int UserRole;
            public static User userinfo { get; set; }
        }



        private void BtnSignIn_Click(object sender, RoutedEventArgs e) //Разграничение с проверкой логина
        {
            var CurrentUser = AppData.db.User.FirstOrDefault(u => u.Login == TxbLogin.Text);
            if (CurrentUser != null)
            {
                Globals.UserRole = CurrentUser.RoleId;
                Globals.userinfo = CurrentUser;
                TxbPassword.IsEnabled = true;
                Autr.Visibility = Visibility.Hidden;
                Autr_2.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!");
            }
        }

        private void Next_Btn(object sender, RoutedEventArgs e)//Переход в приложение после капчи
        {
            if (TXB2.Text == TXB1.Text)

            {
                Sotrudniki ebatb = new Sotrudniki();
                ebatb.Txb_User.Text = TxbLogin.Text;
                ebatb.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Код подтверждения не верный!");
            }
        }
        private async void BtnSignIn_Click_2(object sender, RoutedEventArgs e)
        {
            var CurrentUser1 = AppData.db.User.FirstOrDefault(u => u.Login == TxbLogin.Text && u.Password == TxbPassword.Text); //Разграничение с проверкой логина и пароля
            if (CurrentUser1 != null)
            {
                Globals.UserRole = CurrentUser1.RoleId;
                Globals.userinfo = CurrentUser1;
                if (kapt.Visibility == Visibility.Hidden)
                    kapt.Visibility = Visibility.Visible;
                TxbLogin.IsEnabled = false;
                TxbPassword.IsEnabled = false;
                Autr_2.IsEnabled = false;
                while (true)
                {
                    Random x = new Random();
                    int a = x.Next(1000, 9999);
                    TXB1.Text = a.ToString();
                    await Task.Delay(10000);
                }
            }
            else
            {
                MessageBox.Show("Пароль не верен!");
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e) //Обновление капчи
        {
          
                while (true)
                {
                    Random x = new Random();
                    int a = x.Next(1000, 9999);
                    TXB1.Text = a.ToString();
                    await Task.Delay(10000);
                }
            
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            TxbLogin.Clear();
            TxbPassword.Clear();
            TxbLogin.Focus();
        }
    }
}
