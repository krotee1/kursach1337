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
using Word = Microsoft.Office.Interop.Word;


namespace Testovaya
{
    /// <summary>
    /// Логика взаимодействия для Sotrudniki.xaml
    /// </summary>
    public partial class Sotrudniki : Window
    {
        public Sotrudniki() //Связь датагрида с бд и разграничение
        {
            InitializeComponent();
            UsersGrid2.ItemsSource = PenisEntities.GetContext().Sotrudnikii.ToList();
            MainWindow mainWindow = new MainWindow();

            if (MainWindow.Globals.UserRole == 1)
            {
                
                skrit.Visibility = Visibility.Visible;
            }
            else
            {
                
                skrit.Visibility = Visibility.Collapsed;
            }
            Txb_User.Text = mainWindow.TxbLogin.Text;
        }

        private void ButtonSet_Click(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            Raspisanye raspisanye = new Raspisanye();
            raspisanye.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)//Связь с таблицей сотрудники
        {
            UsersGrid2.ItemsSource = AppData.db.Sotrudnikii.ToList();
        }

        private void Add2_Btn_Click(object sender, RoutedEventArgs e)//Переход на другое окно
        {
            newSotrudnik newSotrudnikk = new newSotrudnik(null);
            newSotrudnikk.Show();
            this.Close();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e) //Кнопка удаления с сохранением изменений в бд
        {
            if (MessageBox.Show("Ты уверен в этом???", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentSotrudnikii = UsersGrid2.SelectedItem as Sotrudnikii;
                AppData.db.Sotrudnikii.Remove(CurrentSotrudnikii);
                AppData.db.SaveChanges();

                UsersGrid2.ItemsSource = AppData.db.Sotrudnikii.ToList();
                MessageBox.Show("Всё удалено");
            }
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)//Переход на окно изменений
        {
            newSotrudnik newSotrudnikk = new newSotrudnik((sender as Button).DataContext as Sotrudnikii);
            newSotrudnikk.Show();
            this.Close();

        }

        private void otchet_Click(object sender, RoutedEventArgs e)//Формирование отчётов, с разметкой в ворде
        {
                var allUsers = PenisEntities.GetContext().User.ToList();
                var allRequest = PenisEntities.GetContext().Sotrudnikii.ToList();

                var application = new Word.Application();

                Word.Document document = application.Documents.Add();

                Word.Paragraph userParagraph = document.Paragraphs.Add();
                Word.Range userRange = userParagraph.Range;
                userRange.Text = "Данные о билетах";

                userRange.InsertParagraphAfter();

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 7);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                    = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Номер поезда";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "Вокзал";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Дата прибытия";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "Откуда";
                cellRange = paymentsTable.Cell(1, 5).Range;
                cellRange.Text = "Куда";
                cellRange = paymentsTable.Cell(1, 6).Range;
                cellRange.Text = "Марка поезда";
                cellRange = paymentsTable.Cell(1, 7).Range;
                cellRange.Text = "Стоимость";


            paymentsTable.Rows[1].Range.Bold = 1;
                paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                for (int i = 0; i < allRequest.Count(); i++)
                {
                    var currentCategory = allRequest[i];
                    if (currentCategory.FullName != null)
                    {
                        cellRange = paymentsTable.Cell(i + 2, 1).Range;
                        cellRange.Text = Convert.ToString(currentCategory.Id);
                        cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        cellRange = paymentsTable.Cell(i + 2, 2).Range;
                        cellRange.Text = Convert.ToString(currentCategory.Adress);

                        cellRange = paymentsTable.Cell(i + 2, 3).Range;
                        cellRange.Text = currentCategory.Date.ToString("dd.MM.yyyy");

                        cellRange = paymentsTable.Cell(i + 2, 4).Range;
                        cellRange.Text = Convert.ToString(currentCategory.Dolzhnost);

                        cellRange = paymentsTable.Cell(i + 2, 5).Range;
                        cellRange.Text = Convert.ToString(currentCategory.Family);

                        cellRange = paymentsTable.Cell(i + 2, 6).Range;
                        cellRange.Text = Convert.ToString(currentCategory.FullName);

                        cellRange = paymentsTable.Cell(i + 2, 7).Range;
                        cellRange.Text = Convert.ToString(currentCategory.Number);
                }
                }

                application.Visible = true;

            
        }
    }
}
