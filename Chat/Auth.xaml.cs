using Newtonsoft.Json;
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
using WebSocketSharp;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Chat
{
    
    public partial class Auth : Page
    {
        WebSocket ws = new WebSocket("ws://127.0.0.1:8888");

        public Auth()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserData user = new UserData();
            user.Name = login.Text;
            user.Password = password.Text;
            user.Message = "";
            user.UserWant = "auth";

            var json = JsonConvert.SerializeObject(user);

            ws.Connect();

            ws.Send(json);

            ws.OnMessage += (sender1, e1) =>
            {
                
                UserData m = JsonConvert.DeserializeObject<UserData>(e1.Data);

                if (m.Name == $"{user.Name}" && m.UserWant == "auth")
                {

                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    {
                        
                        var window = new Messages(e1.Data.ToString());
                        NavigationService.Navigate(window);
                       
                        ((MainWindow)System.Windows.Application.Current.MainWindow).lb1.Content = m.Name;
                        
                    });

                }

                
            };

            
        }
    }
}
