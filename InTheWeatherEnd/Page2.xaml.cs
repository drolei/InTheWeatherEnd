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
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace InTheWeatherEnd
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        string answer;



        private async void StartBT_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                WebRequest request = WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q={TBquest.Text}&appid=7393c0b87721025667e362f3908a3f0e");
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";

                WebResponse response = await request.GetResponseAsync();

                answer = string.Empty;

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }

                response.Close();
            }
            catch (WebException ex)
            {
                try
                {
                    HttpWebResponse errorResponse = (HttpWebResponse)ex.Response;
                    if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("неправильно введён город");
                    }
                }

                catch
                {
                    MessageBox.Show("не удаётся подключится к серверу");
                    answer = "Eror";
                }
            }






            /*FlowDocument rr = new FlowDocument();
            Paragraph tt = new Paragraph();
            tt.Inlines.Add(new Run(answer));
            rr.Blocks.Add(tt);*/


            //RTb.Document = rr;
            if (answer !="Eror") {
                OpenWeather.OpenWeather OW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

                image.Source = convert.Convert(OW.weather[0].Icon);
                Lmain.Content = "" + OW.weather[0].main;
                Ldiscription.Content = "" + OW.weather[0].description;
                Ltemp.Content = "Средняя температура (°С) " + Math.Round(OW.main.temp, 3);
                Lspeed.Content = "Скорость ветра (м/с) " + OW.wind.speed;
                Ldeg.Content = "Направление ветра (градусов) " + OW.wind.deg;
                Lhumidity.Content = "Влажность (%) " + OW.main.humidity;
                Lpressure.Content = "Давление (мм рт. ст.) " + ((int)OW.main.pressure);
            }


        }
    }
}
