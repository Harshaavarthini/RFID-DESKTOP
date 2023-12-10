using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
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
using System.Windows.Threading;

namespace UPS__DESKTOP_1
{

    public partial class MainWindow : Window, IDisposable
    {

        public Connect Rfid;
        public string awb;
        public string data;
        private SerialPort _currentPort;
        Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        public static Message messageBox = new();
        public static ErrorMessage errorMessage = new ErrorMessage();


        public MainWindow()
        {
            InitializeComponent();

        }
        
        //register and link
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //if (_currentPort is not null)
            //{
            //    if (_currentPort.IsOpen)
            //    {
            //        _currentPort.Close();
            //        _currentPort.Open();
            //    }
            //}
            ////Rfid = new Connect();
            //string comport = Rfid.GetComPort();
            //if (comport == null)
            //{
            //    comport =  Comport.comport_static.ToString();
            //}
            //Debug.WriteLine("comport :" + comport);
            //int baudrate = 38400;
            //if (comport == "Impinj")
            //{
            //    baudrate = 0;
            //}
            //_currentPort = new SerialPort(comport)
            //{

            //    BaudRate = baudrate
            //};
            //Debug.WriteLine("_currentport: "+_currentPort);
            //_currentPort.DataReceived += _currentPort_DataReceived;
            ////_currentPort.ErrorReceived += _currentPort_ErrorReceived;

            //TryConnect();

            Post_Method(data, awb);

        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            Rfid = new Connect();
            Rfid.Show();
            if (Comport.comport_static != null)
            {
                txtCONNECT.Text = "CONNECTED";
                connectBUTTON.Background = Brushes.Green;
                //Debug.WriteLine(txtCONNECT.Text);
            }
        }

        private void CloseButton_Click(object sender, MouseButtonEventArgs e)
        {
            
            mainWindow.Close();
        }


        //get details
        private async void detailsButton_Click(object sender, RoutedEventArgs e)
        {


            awb = txtAWB.Text;
            Debug.WriteLine(awb);
            using (HttpClient client = new HttpClient())
            {

                string url = $"http://172.22.81.182:8080/rfid/getdetails/{awb}";

                Debug.WriteLine(url);
                //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.GetAsync(url);


                if (response.IsSuccessStatusCode)
                {

                    var responseContent = await response.Content.ReadAsStringAsync();
                    //MessageBox.Show($"{responseContent}");
                    //var Items = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent);
                    //Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                    Details json = JsonConvert.DeserializeObject<Details>(responseContent);
                    //MessageBox.Show("Registration Successful! Response: " + json);

                    txtPRODUCT.Text = json.product_details;
                    txtDIMENSIONS.Text = json.dimensions;
                    txtSENDER.Text = json.sender_data;
                    txtSENDERPHONE.Text = json.sender_phone;
                    txtRECEIVER.Text = json.receiver_data;
                    txtRECEIVERPHONE.Text = json.receiver_phone;
                    txtORIGIN.Text = json.origin_data;
                    txtDESTINATION.Text = json.destination_data;

                    //scan rfid


                    if (_currentPort is not null)
                    {
                        if (_currentPort.IsOpen)
                        {
                            _currentPort.Close();
                            _currentPort.Open();
                        }
                    }
                    //Rfid = new Connect();
                    string comport = Rfid.GetComPort();
                    if (comport == null)
                    {
                        comport = Comport.comport_static.ToString();
                    }
                    Debug.WriteLine("comport :" + comport);
                    int baudrate = 38400;
                    if (comport == "Impinj")
                    {
                        baudrate = 0;
                    }
                    _currentPort = new SerialPort(comport)
                    {

                        BaudRate = baudrate
                    };
                    Debug.WriteLine("_currentport: " + _currentPort);
                    _currentPort.DataReceived += _currentPort_DataReceived;
                    //_currentPort.ErrorReceived += _currentPort_ErrorReceived;

                    TryConnect();
                }


                else
                {

                    MessageBox.Show("DETAILS FETCH FAILED. Status Code: " + response.StatusCode);
                }
            }
            



        }

        private void TryConnect()
        {
            try
            {
                if (!_currentPort.IsOpen)
                {
                    _currentPort.Open();
                }
                
               
            }
            catch(Exception ex) 
            {
                
                MessageBox.Show(ex.Message);
                Debug.WriteLine(ex.Message);
            }
        }

        private void _currentPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            //Debug.WriteLine(e.ToString());
            MessageBox.Show("Serial error");
        }

        private void _currentPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string inData = _currentPort.ReadLine().Replace("\n", "")
                    .Replace("\r", "");
                //inData = inData.Substring(inData.Length, 4);
                if (inData.Length > 16)
                {
                    inData = inData.Remove(0, 5);
                    inData = inData.Remove(inData.Length - 4, 4);
                    Debug.WriteLine(inData);
                    dispatcher.BeginInvoke(() =>
                    {
                        txtRFID.Text = inData;
                        txtRFID.IsEnabled = false;
                    });
                    data = inData;
                    _currentPort.DataReceived -= _currentPort_DataReceived;
                    _currentPort.Close();
                    
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show(_currentPort.ToString());
                _currentPort.Close();
            }
        }

        public void Dispose()
        {
            _currentPort.Close();
            GC.Collect();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtRFID.Text = "";
            txtPRODUCT.Text = "";
            txtDIMENSIONS.Text = "";
            txtSENDER.Text = "";
            txtSENDERPHONE.Text = "";
            txtRECEIVER.Text = "";
            txtRECEIVERPHONE.Text = "";
            txtORIGIN.Text = "";
            txtDESTINATION.Text = "";
            txtAWB.Text = "";
        }

        //[STAThread]
        public async void Post_Method(string rfid, string awb)
        {

            var data = new Dictionary<string, string>
            {
                { "rfid", rfid },
                { "awb", awb },

            };

            string json = JsonConvert.SerializeObject(data);
            using (HttpClient client = new HttpClient())
            {

                string url = "http://172.22.81.182:8080/rfid/linkrfid";


                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.PostAsync(url, content);


                if (response.IsSuccessStatusCode)
                {

                    string responseContent = await response.Content.ReadAsStringAsync();
                    //MessageBox.Show("Registration Successful! Response: ");
                    dispatcher.Invoke(() => {
                        messageBox.Foreground = Brushes.Green;
                        messageBox.Background = Brushes.White;
                        //showErrorBox();
                        //messageBox.SetCurrentValue = "Regsitration Successful";
                        messageBox.Show();
                    });


                }
                else
                {

                    //MessageBox.Show("Registration Failed. Status Code: " + response.StatusCode);
                    
                    dispatcher.Invoke(()=>{
                        txtRFID.Text = "--.--.--";
                        showErrorBox();
                    });
                    
    

                }
            }
        }

        public static void showErrorBox()
        {
            errorMessage.Show();
        }

    }
}






