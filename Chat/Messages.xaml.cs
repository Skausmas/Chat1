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

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для Messages.xaml
    /// </summary>
    public partial class Messages : Page
    {
        WebSocket ws = new WebSocket("ws://127.0.0.1:8888");

        public Messages(string ud)
        {
            InitializeComponent();
            //UserData m = JsonConvert.DeserializeObject<UserData>(ud);

            ws.Connect();

            ws.OnMessage += (sender1, e1) =>
            {

                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                   
                    UserData m = JsonConvert.DeserializeObject<UserData>(e1.Data);

                    if (m.UserWant == "whisper")
                    {
                        TextBlockChat.Text = $"From {m.Name}: " + m.Message + "\n";
                        TextBlockChat.Text = e1.Data.ToString();
                    }

                    if (m.UserWant == "mesAll")
                    {
                        TextBlockChat.Text = m.Message + "\n";
                    }

                });



            };



        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            UserData user = new UserData();
            user.Name = ((MainWindow)System.Windows.Application.Current.MainWindow).lb1.Content.ToString();
            user.Password = "";
            user.Message = "sasai";
            user.UserWant = "mesAll";
            user.WSID = "";

            var json = JsonConvert.SerializeObject(user);

           

            ws.Send(json);
        }
    }
}
