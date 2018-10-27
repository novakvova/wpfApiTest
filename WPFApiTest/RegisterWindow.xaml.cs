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
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string jsonObject = JsonConvert.SerializeObject(new
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text
            });
            string url = "http://localhost:1111/api/Account/Register";
            var content = new StringContent(jsonObject,Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).Result;
            MessageBox.Show(result.StatusCode.ToString());
            if(result.StatusCode==System.Net.HttpStatusCode.OK)
                this.Close();
        }
    }
}
