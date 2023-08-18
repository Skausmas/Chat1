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

    public partial class MainWindow : Window

    {

        WebSocket ws = new WebSocket("ws://127.0.0.1:8888");

        Auth a1 = new Auth();

        public string name { get; set; }

        

        public MainWindow()
        {
            InitializeComponent();

            Frame1.Content = a1;

            ws.Connect();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {

         
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
