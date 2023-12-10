using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
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

namespace UPS__DESKTOP_1
{
    public partial class Connect : Window
    {
        public Connect()
        {
            InitializeComponent();
            this.Top = 900;
            this.Left = 100;
        }

        string[] COMPorts;
        public string comport { get; private set; }
        string baudrate;
        //Comport com = new();
        
        private void CloseButton_Click(object sender, MouseButtonEventArgs e)
        {

            this.Close();
        }

        public string GetComPort()
        {
            Debug.WriteLine(comport);

            return comport;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            comport = txtCOMPort.Text;
            //baudrate = txtBAUDRATE.Text;
            this.Close();
        }


        private void GetCOMPorts()
        {
            COMPorts = SerialPort.GetPortNames();
            //Debug.WriteLine(COMPorts.Length);
            txtCOMPort.ItemsSource = COMPorts;
            if (COMPorts.Any())
            {
                txtCOMPort.SelectedIndex = 0;
            }
        }

        private void ConnectWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetCOMPorts();
        }

        private void txtCOMPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comport = txtCOMPort.SelectedValue.ToString();
            Comport.comport_static = comport;

            //Debug.WriteLine(comport);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
