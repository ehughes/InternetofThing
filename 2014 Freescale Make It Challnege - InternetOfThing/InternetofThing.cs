using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Net;
using System.Web;

using System.IO;
using System.Net.Sockets;

namespace InternetOfThing
{
    public partial class MainForm : Form
    {

        string SerialPortConnectionState = "Not Connected";
        string TCP_PortConnectionState = "Not Connected";

        Thread SerialPortConnectionManager;
        SerialPort MySerialPort;
        Thread TCP_PortConnectionManager;
        TcpClient MyTCP_Port;

        bool KillAllThreads = false;

        System.Windows.Forms.Timer FormUpdateTimer = new System.Windows.Forms.Timer();

        Pen CirclePen = new Pen(Color.Red, 4.0f);

        Pen LinePen = new Pen(Color.LimeGreen, 4.0f);
        //StreamReader MyTCP_ReadStream;
        StreamWriter MyTCP_WriteStream;

        Point ThingLocation;

        int[] CenterOfMass = new int[2];

        string NextCMD = "";

        double StopRadius = 0.20;

        public MainForm()
        {
            InitializeComponent();

            SerialPortConnectionManager = new Thread(new ThreadStart(SerialPortManager));

            SerialPortConnectionManager.Start();

            TCP_PortConnectionManager = new Thread(new ThreadStart(TCP_PortManager));
            TCP_PortConnectionManager.Start();

            COM_PortComboBox.Items.Clear();

            foreach (string S in SerialPort.GetPortNames())
            {
                COM_PortComboBox.Items.Add(S);
            }

            if (COM_PortComboBox.Items.Count > 0)
                COM_PortComboBox.SelectedIndex = 0;


            FormUpdateTimer.Tick += new EventHandler(FormUpdateTimer_Tick);
            FormUpdateTimer.Interval = 50;
            FormUpdateTimer.Start();

            ResizeForm();

            ThingLocation.X = ThingBox.Width / 2;
            ThingLocation.Y = ThingBox.Height / 2;
         
        }

        void FormUpdateTimer_Tick(object sender, EventArgs e)
        {
            switch (SerialPortConnectionState)
            {
                default:
                case "Not Connected":
                    ConnectButton.Text = "Serial Connect";
                    break;

                case "Connected":
                    ConnectButton.Text = "Serial Disconnect";
                    break;
            }

            switch (TCP_PortConnectionState)
            {
                default:
                case "Not Connected":
                    TCP_ConnectButton.Text = "TCP Connect";
                    break;

                case "Connected":
                    TCP_ConnectButton.Text = "TCP Disconnect";
                    break;
            }



            if (MySerialPort != null && MySerialPort.IsOpen)
            {
                if (NextCMD != "")
                MySerialPort.WriteLine(NextCMD);
                NextCMD = "";
            }
            if (MyTCP_Port != null && MyTCP_Port.Connected == true)
            {
                try { 
                if(NextCMD !="")
                 MyTCP_WriteStream.WriteLine(NextCMD + "\r\n");
                 MyTCP_WriteStream.Flush();
                NextCMD = "";
                 }
                catch (Exception Ex)
                {


                }

            }
        }

        void DecodeString(string NextLineIn)
        {
      
        }

        void SerialPortManager()
        {


            while (KillAllThreads == false)
            {
                Thread.Sleep(1);

                switch (SerialPortConnectionState)
                {
                    default:
                    case "Not Connected":
                        break;

                    case "Connected":

                        lock (MySerialPort)
                        {
                            if (MySerialPort != null && MySerialPort.IsOpen == true)
                            {

                                try
                                {

                                    string NextLineIn = MySerialPort.ReadLine().Trim();

                                    DecodeString(NextLineIn);
      
                                    

                                }
                                catch
                                {

                                }
                            }
                        }

                        break;
                }
            }

            return;
        }

        void TCP_PortManager()
        {


            while (KillAllThreads == false)
            {
                Thread.Sleep(1);

                switch (TCP_PortConnectionState)
                {
                    default:
                    case "Not Connected":
                        break;

                    case "Connected":

                        lock (MyTCP_Port)
                        {
                            if (MyTCP_Port != null && MyTCP_Port.Connected == true)
                            {

                                try
                                {

                                  // string NextLineIn = MyTCP_ReadStream.ReadLine();

                                  // DecodeString(NextLineIn);



                                }
                                catch
                                {

                                }
                            }
                        }

                        break;
                }
            }

            return;
        }


        int[] ConvertHexToInts(string In)
        {
            string[] Hex = In.Split(',');

            int[] Values = new int[Hex.Length];

            for (int i = 0; i < Values.Length; i++)
            {
                try
                {
                    Values[i] = Convert.ToInt32(Hex[i], 16);
                }
                catch (Exception Ex)
                {
                    Values[i] = 0;

                }
            }

            return Values;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
             switch(SerialPortConnectionState)
            {
                case "Not Connected":

                    try
                    {
                        MySerialPort = new SerialPort();

                        MySerialPort.PortName = COM_PortComboBox.SelectedItem.ToString();

                        MySerialPort.BaudRate = 115200;

                        MySerialPort.NewLine = "\r";
                        MySerialPort.ReadTimeout = 1000;

                        MySerialPort.Open();

                     
                        SerialPortConnectionState = "Connected";
                    }
                   catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Connection Error");
                    }
                        
                    break;

                case "Connected":
                    if(MySerialPort!=null)
                    {
                        try
                        {

                            MySerialPort.Close();
                            SerialPortConnectionState = "Not Connected";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message, "Disconnection Error");
                        }
                    }
                    break;

            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         KillAllThreads = true;

            if (MySerialPort != null)
            {
                MySerialPort.Close();
            }
        }

        private void plot1_Click(object sender, EventArgs e)
        {

        }

        private void TCP_ConnectButton_Click(object sender, EventArgs e)
        {
           switch(TCP_PortConnectionState)
            {
                case "Not Connected":

                    try
                    {
                      
                        MyTCP_Port = new TcpClient();
                    
                        MyTCP_Port.Connect(new IPEndPoint(IPAddress.Parse(IP_TB.Text),Convert.ToInt32(TCP_PORT_TB.Text)));

                      
                       // MyTCP_ReadStream = new StreamReader(MyTCP_Port.GetStream());
                        MyTCP_WriteStream = new StreamWriter(MyTCP_Port.GetStream());

                        TCP_PortConnectionState = "Connected";
                    }
                   catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message,"Connection Error");
                    }
                        
                    break;

                case "Connected":
                    if(TCP_PortConnectionState!=null)
                    {
                        try
                        {

                            MyTCP_Port.Close();
                            TCP_PortConnectionState = "Not Connected";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message, "Disconnection Error");
                        }
                    }
                    break;

            }
        }

        private void ThingBox_Click(object sender, EventArgs e)
        {
             ThingLocation.X = ThingBox.Width / 2;
            ThingLocation.Y = ThingBox.Height / 2;
            ThingBox.Invalidate();

          
        
           // SendThingCommand("thing_stop");
        }

        
        private void ThingBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            Point L = new Point();

            L.X = ThingLocation.X - global::InternetOfThing.Properties.Resources.thing.Width / 2;
            L.Y = ThingLocation.Y - global::InternetOfThing.Properties.Resources.thing.Height / 2;

            double Mag = Math.Sqrt((double)ThingBox.Width*(double)ThingBox.Width + (double)ThingBox.Height * (double)ThingBox.Height);

            Mag = Mag * StopRadius;


            double xC = Mag/2 * Math.Cos(-45 * Math.PI / 180.0);
            double yC = Mag/2 * Math.Sin(-45 * Math.PI / 180.0);

            xC += ((double)ThingBox.Width / (double)2);
            yC = ((double)ThingBox.Height / (double)2) + yC;

            e.Graphics.DrawLine(LinePen,
                                   (int)xC,
                                   (int)yC,
                                   (int)ThingBox.Width,
                                   (int)0);


            xC = Mag / 2 * Math.Cos(45 * Math.PI / 180.0);
             yC = Mag / 2 * Math.Sin(45 * Math.PI / 180.0);

            xC += ((double)ThingBox.Width / (double)2);
            yC = ((double)ThingBox.Height / (double)2) + yC;

            e.Graphics.DrawLine(LinePen,
                                   (int)xC,
                                   (int)yC,
                                   (int)ThingBox.Width,
                                   (int)ThingBox.Height);

            xC = Mag / 2 * Math.Cos(135 * Math.PI / 180.0);
            yC = Mag / 2 * Math.Sin(135 * Math.PI / 180.0);

            xC += ((double)ThingBox.Width / (double)2);
            yC = ((double)ThingBox.Height / (double)2) + yC;

            e.Graphics.DrawLine(LinePen,
                                   (int)xC,
                                   (int)yC,
                                   (int)0,
                                   (int)ThingBox.Height);


            xC = Mag / 2 * Math.Cos(-135 * Math.PI / 180.0);
            yC = Mag / 2 * Math.Sin(-135 * Math.PI / 180.0);

            xC += ((double)ThingBox.Width / (double)2);
            yC = ((double)ThingBox.Height / (double)2) + yC;

            e.Graphics.DrawLine(LinePen,
                                   (int)xC,
                                   (int)yC,
                                   (int)0,
                                   (int)0);

            e.Graphics.DrawEllipse(CirclePen,
                                 (ThingBox.Width / 2) - (int)(Mag/2),
                                 (ThingBox.Height / 2) - (int)(Mag/2),
                                 (int)Mag,
                                 (int)Mag);


            e.Graphics.DrawImage(global::InternetOfThing.Properties.Resources.thing, L);
        }

        private void ThingBox_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ThingLocation = e.Location;

                double X, Y;

                X = ((double)ThingLocation.X / (double)ThingBox.Width) * 2.0 - 1.0;
                Y = ((double)ThingLocation.Y / (double)ThingBox.Height) * 2.0 - 1.0;

                double Angle = Math.Atan2(Y, X) * 360 / (2 * Math.PI);

                double Mag = Math.Sqrt(X * X + Y * Y);


                if (Mag > StopRadius)
                {

                    if (Angle > -45 && Angle < 45)
                    {

                        SendThingCommand("thing_cw");
                    }

                    if ((Angle > 135 && Angle < 180) || (Angle > -180 && Angle < -135))
                    {
                        SendThingCommand("thing_ccw");
                    }

                    if (Angle < -45 && Angle > -135)
                    {
                        SendThingCommand("thing_go");

                    }

                    if (Angle > 45 && Angle < 135)
                    {
                        SendThingCommand("thing_back");
                    }

                }
                else
                {
                    SendThingCommand("thing_stop");

                }

                ThingBox.Invalidate();
            }
            else
            {
                ThingLocation.X = ThingBox.Width / 2;
                ThingLocation.Y = ThingBox.Height / 2;
                ThingBox.Invalidate();
            }
        }

        private void ThingBox_MouseUp(object sender, MouseEventArgs e)
        {
            ThingLocation.X = ThingBox.Width / 2;
            ThingLocation.Y = ThingBox.Height / 2;
            ThingBox.Invalidate();
           SendThingCommand("thing_stop");
        }
    

        void SendThingCommand(string CMD)
        {
            DebugTB.Text = CMD;

            NextCMD = CMD;


        }

        private void ThingBox_MouseLeave(object sender, EventArgs e)
        {
            ThingLocation.X = ThingBox.Width / 2;
            ThingLocation.Y = ThingBox.Height / 2;
            ThingBox.Invalidate();
    

        }


        void ResizeForm()
        {
            ThingBox.Width = this.Width - 30 - ThingBox.Location.X;
            ThingBox.Height = this.Height - 50 - ThingBox.Location.Y;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeForm();
            ThingBox.Invalidate();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
