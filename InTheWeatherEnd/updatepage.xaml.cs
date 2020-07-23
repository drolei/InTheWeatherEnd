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

namespace InTheWeatherEnd
{
    /// <summary>
    /// Логика взаимодействия для updatepage.xaml
    /// </summary>
    public partial class updatepage : Window
    {
        
        WeatherEntities _db = new WeatherEntities();
        int id;
        public updatepage(int weatherId)
        {
            InitializeComponent();
            id = weatherId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataWeather dataWeathers = (from m in _db.DataWeathers
                                            where m.Id == id
                                            select m).Single();
                dataWeathers.Date = Dates.Text;
                dataWeathers.time = times.Text;
                dataWeathers.weather = weathers.Text;
                dataWeathers.windDeg = windDegs.Text;
                dataWeathers.middleTemp = Convert.ToDouble(middleTEMPS.Text);
                dataWeathers.windSpeed = Convert.ToDouble(Windspeeds.Text);
                dataWeathers.humidity = Convert.ToDouble(humidities.Text);
                dataWeathers.pressure = Convert.ToDouble(pressures.Text);




                _db.SaveChanges();

                Page1.datagrid.ItemsSource = _db.DataWeathers.ToList();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("erore");
            }


        }
    }
}
