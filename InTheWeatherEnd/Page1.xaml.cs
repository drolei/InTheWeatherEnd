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
using System.Data.OleDb;
using System.Data;

namespace InTheWeatherEnd
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        WeatherEntities _db = new WeatherEntities();
        public static DataGrid datagrid;
        public Page1()
        {

            InitializeComponent();
            Load();

        }

        private void Load()
        {
            datagridMy.ItemsSource = _db.DataWeathers.ToList();
            datagrid = datagridMy;
        }

        private void insertbtn_Click(object sender, RoutedEventArgs e)
        {
            insertpage ipage = new insertpage();
            ipage.ShowDialog();
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (datagridMy.SelectedItem as DataWeather).Id;
                updatepage uppage = new updatepage(id);
                uppage.ShowDialog();
            }
            catch
            {
                MessageBox.Show("erore");
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (datagridMy.SelectedItem as DataWeather).Id;
                var deleteweather = _db.DataWeathers.Where(m => m.Id == id).Single();
                _db.DataWeathers.Remove(deleteweather);
                _db.SaveChanges();
                datagridMy.ItemsSource = _db.DataWeathers.ToList();
            }
            catch
            {
                MessageBox.Show("erore");
            }
        }
    }
}
