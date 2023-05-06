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
    /// Логика взаимодействия для kapcha.xaml
    /// </summary>
    public partial class kapcha : Window
    {
        public kapcha()
        {
            InitializeComponent();
        }

        private void Btn_NextFromCapcha_Click(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }
    }
}
