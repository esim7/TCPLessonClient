using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace TCPClient
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

        private void GoButton(object sender, RoutedEventArgs e)
        {
            using (var client = new TcpClient())
            {
                client.Connect(new IPEndPoint(IPAddress.Parse("10.1.4.41"), 3231));
                using (var stream = client.GetStream())
                {
                    var data = Encoding.UTF8.GetBytes(messageBox.Text);
                    stream.Write(data, 0, data.Length);                                  
                    var buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);
                    var resultText = System.Text.Encoding.UTF8.GetString(buffer);                 
                    messageBox.Text = resultText;
                }
            }
        }
    }
}
