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
    /// Логика взаимодействия для insertpage.xaml
    /// </summary>
    public partial class insertpage : Window
    {
        
        WeatherEntities _db = new WeatherEntities();
        public insertpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataWeather dataWeathers = new DataWeather()
                {
                    Date = Dates.Text,
                    time = times.Text,
                    weather = weathers.Text,
                    windDeg = windDegs.Text,
                    middleTemp = Convert.ToDouble(middleTEMPS.Text),
                    windSpeed = Convert.ToDouble(Windspeeds.Text),
                    humidity = Convert.ToDouble(humidities.Text),
                    pressure = Convert.ToDouble(pressures.Text)

                };

                _db.DataWeathers.Add(dataWeathers);
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
