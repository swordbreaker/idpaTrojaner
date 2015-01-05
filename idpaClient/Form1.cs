using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdpaTools;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace IdpaClient
{
    public partial class Form1 : Form
    {
        private const string LOG_PATH = @"C:\Temp\log.xml";
        private Logger logger;

        public Form1()
        {
            InitializeComponent();
            logger = new Logger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listener();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger = Serilizer.getDataFromFile(LOG_PATH, logger);
            string tempOutput;
            textBox1.Text = "";

            foreach(ApplicationLog app in logger.applicationLog)
            {
                tempOutput = app.processName + " (" + app.date + ") \r\n";
                textBox1.AppendText(tempOutput);

                foreach(string key in app.keyList)
                {
                    textBox1.AppendText(key + " ");
                }
                textBox1.AppendText("\r\n");
            }
        }

        private void Listener()
        {
            TcpListener server=null;   
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while(true) 
                {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();            
                Console.WriteLine("Connected!");

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                while((i = stream.Read(bytes, 0, bytes.Length))!=0) 
                {   
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    // Process the data sent by the client.
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);            
                }

                // Shutdown and end connection
                client.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        private void Listener_old()
        {
            var listener = new TcpListener(IPAddress.Loopback, 11000);
            listener.Start();

            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                using (var stream = client.GetStream())
                using (var output = File.Create("result.dat"))
                {
                    Console.WriteLine("Client connected. Starting to receive the file");

                    textBox1.Text = "Client connected. Starting to receive the file";

                    // read the file in chunks of 1KB
                    var buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }

                    textBox1.Text = "Success";
                }
            }
        }
    }
}
