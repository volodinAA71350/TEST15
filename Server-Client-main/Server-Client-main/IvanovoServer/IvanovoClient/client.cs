using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Windows.Input;

namespace IvanovoClient
{
    public partial class client : Form
    {
        Socket socket;

        private void SendToServer(string command)
        {
            byte[] data = Encoding.UTF8.GetBytes(command);
            socket.Send(data);
        }

        public client()
        {
            InitializeComponent();
        }

        private void client_Load(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
                socket.Connect(textBoxHost.Text, Int32.Parse(textBoxPort.Text));
                
                SendToServer("name " + textBoxName.Text);
                
                timerClient.Enabled = true;
                
                textBoxLogClient.AppendText("Подключено к " + textBoxHost.Text +":"+ textBoxPort.Text + "\r\n");
                
                buttonConnect.Enabled = false;
                
                buttonDisconnect.Enabled = true;
            }
            catch(Exception exc)
            {
                textBoxLogClient.AppendText(exc.Message + "\r\n");
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                SendToServer("quit");
                
                socket.Shutdown(SocketShutdown.Both);
                
                socket.Close();
                
                timerClient.Enabled = false;
                
                buttonConnect.Enabled = true;
                
                buttonDisconnect.Enabled = false;
                
                textBoxLogClient.AppendText("Отключено\r\n");
            }
            catch (Exception exc)
            {
                textBoxLogClient.AppendText(exc.Message + "\r\n");
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try 
            {
                SendToServer("message " + textBoxMessage.Text);
                textBoxLogClient.AppendText(textBoxName.Text +": "+ textBoxMessage.Text +"\r\n");
            }
            
            catch(Exception exc)
            {
                textBoxLogClient.AppendText(exc.Message + "\r\n");
            }
        }

        private void TimerClient_Tick(object sender, EventArgs e)
        {
            try
            {
                if (socket.Available > 0)
                {
                    byte[] data = new byte[socket.Available];
                    
                    int data_size = socket.Receive(data);
                    
                    string text_data = Encoding.UTF8.GetString(data, 0, data_size);

                    if (text_data.StartsWith("new "))
                    {
                        textBoxLogClient.AppendText(text_data.Substring(4) + " вошёл в чат \r\n");
                    }

                    if (text_data.StartsWith("exit "))
                    {
                        textBoxLogClient.AppendText(text_data.Substring(5) + " покинул чат \r\n");
                    }

                    if (text_data.StartsWith("message "))
                    {
                        textBoxLogClient.AppendText(text_data.Substring(8) + "\r\n");
                    }
                }
            }
            catch (Exception exc)
            {
                textBoxLogClient.AppendText(exc.Message + "\r\n");
            }
        }
    }
}
