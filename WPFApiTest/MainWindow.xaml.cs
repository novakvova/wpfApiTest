using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WPFApiTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow dlg = new RegisterWindow();
            dlg.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow dlg = new LoginWindow();
            var result = dlg.ShowDialog();
            if(result!=null && result==true)
            {
                var token = dlg.Token;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                   new System.Net.Http.Headers
                   .AuthenticationHeaderValue(token.token_type, token.access_token);
                string url = "http://localhost:1111/api/Values";
                var response = client.GetAsync(url).Result;
                if(response.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    HttpContent resContent = response.Content;
                    var json = resContent.ReadAsStringAsync().Result;
                    var mas = JsonConvert.DeserializeObject<string[]>(json);
                    foreach (var item in mas)
                    {
                        lblDataServer.Content += item+" ";
                    }
                }
            }
        }
    }
}
