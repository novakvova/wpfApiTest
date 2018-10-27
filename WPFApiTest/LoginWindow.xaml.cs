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
using System.Windows.Shapes;

namespace WPFApiTest
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public TokenModel Token { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> p = new Dictionary<string, string>();
            string url = "http://localhost:1111/Token";
            p.Add("username", txtEmail.Text);
            p.Add("password", txtPassword.Text);
            p.Add("grant_type", "password");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                    new FormUrlEncodedContent(p)).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                Token = JsonConvert.DeserializeObject<TokenModel>(json);
                //JsonConvert.DeserializeAnonymousType(json,
                //    new { access_token = "", token_type = "" });
                //MessageBox.Show(json);
                //MessageBox.Show(tokenModel.access_token);
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
