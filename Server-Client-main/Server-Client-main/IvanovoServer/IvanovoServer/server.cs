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

namespace IvanovoServer
{
    public partial class Server : Form
    {
        class ClientInfo
        {
            public Socket socket;
            public string name;

            public override string ToString()
            {
                return name + " (" + socket.RemoteEndPoint + ")";
            }
        }

        TcpListener listener;
        List<ClientInfo> clients;

        public Server()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonBind_Click(object sender, EventArgs e)
        {
            try
            {
                int localPort = Int32.Parse(textBoxLocalPort.Text);
                
                IPEndPoint localPoint = new IPEndPoint(IPAddress.Any, localPort);
                
                listener = new TcpListener(localPoint);
                
                listener.Start();
                
                clients = new List<ClientInfo>();
                
                timerServer.Enabled = true;
                
                textBoxLogServer.AppendText("Открыт TCP порт " + textBoxLocalPort.Text + "\r\n");
            }
            catch (Exception exc)
            {
                textBoxLogServer.AppendText(exc.Message + "\r\n");
            }
        }

        private void TimerServer_Tick(object sender, EventArgs e)
        {
            try 
            {
                CheckListener();

                for (int i = clients.Count - 1; i >= 0; i--)
                {
                    ClientInfo client = clients[i];

                    if (client.socket.Available > 0)
                    {
                        byte[] data = new byte[client.socket.Available];
                        
                        int data_size = client.socket.Receive(data);
                        
                        string text_data = Encoding.UTF8.GetString(data, 0, data_size);
                        
                        DoClient(client, text_data);
                    }
                }

            }
            catch (Exception exc)
            {
                textBoxLogServer.AppendText(exc.Message + "\r\n");
            }
        }

        private void CheckListener()
        {
            if (listener.Pending())
            {
                ClientInfo newClient = new ClientInfo();
               
                newClient.socket = listener.AcceptSocket();
               
                clients.Add(newClient);
               
                textBoxLogServer.AppendText("Пользователь " + newClient.socket.RemoteEndPoint + " подключился\r\n");
            }
        }

        private void DoClient(ClientInfo client, string text_data)
        {
            if (text_data.StartsWith("name "))
            {
                client.name = text_data.Substring(5);
               
                listBoxClients.Items.Add(client);
                
                SendToClients("new " + client.name, client);
                
                textBoxLogServer.AppendText("Пользователь " + client.socket.RemoteEndPoint + " Выбрал имя " + client.name +"\r\n");
            }

            if (text_data == "quit")
            {
                SendToClients("exit " + client.name, client);
                
                textBoxLogServer.AppendText("Пользователь " + client.socket.RemoteEndPoint + "покинул комнату \r\n");
                
                client.socket.Shutdown(SocketShutdown.Both);
               
                client.socket.Close();
                
                listBoxClients.Items.Remove(client);
                
                clients.Remove(client);
            }

            if (text_data.StartsWith("message "))
            {
                string message = text_data.Substring(8);
                
                SendToClients("message " + client.name +": "+ message, client);
                
                textBoxLogServer.AppendText(client.name+": "+message + "\r\n");
            }
        }

        private void SendToClients(string command, ClientInfo exceptOf)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                ClientInfo client = clients[i];
                if (client != exceptOf)
                {
                    try
                    {
                        byte[] data = Encoding.UTF8.GetBytes(command);
                        client.socket.Send(data);
                    }
                    catch(Exception exc)
                    {
                        textBoxLogServer.AppendText(exc.Message + "\r\n");
                    }
                }
            }
        }
    }
}
