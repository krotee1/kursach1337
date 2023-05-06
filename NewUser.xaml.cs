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
using Testovaya.Model;
using System.Windows.Navigation;

namespace Testovaya
{
    /// <summary>
    /// Логика взаимодействия для NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
            CmbRole.ItemsSource = AppData.db.Role.ToList();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            User people = new User();

            people.Login = LoginTxb.Text;
            people.Password = Password_Txb.Text;

            var CurrentRole = CmbRole.SelectedItem as Role;
            ;
            people.RoleId = CurrentRole.Id;

            AppData.db.User.Add(people);
            AppData.db.SaveChanges();
            MessageBox.Show("Добавлено");

            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();

        }

        private void CmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
