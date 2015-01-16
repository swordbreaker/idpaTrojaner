using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace idpaServer
{
    class ConnectionManager
    {
        private IPAddress localIpAdress;
        private IPAddress ClientIpAdress;

        public static void Main(string[] args)
        {
            //saveClientDataToServer("http://www.swordbreacker.ch/idpa/index.php", "testName", "Windows Blabla");

            Console.WriteLine(HasClientIpChangend("http://www.swordbreacker.ch/idpa/getip.php", 42));

            string msg = Console.ReadLine();

            SendFileToClient("127.0.0.1", @"C:\Temp\log.xml");
        }

        public static string GetLocalIp()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                localIP = ip.ToString();
                break;
                }
            }
            return localIP;
        }

        public static async void SendFileToClient(String server, String filePath)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 8080;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                byte[] data = new byte[File.ReadAllBytes(filePath).Length];
                data = File.ReadAllBytes(filePath);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                await stream.WriteAsync(data, 0, data.Length);
                //stream.Write(data, 0, data.Length);

                // Receive the TcpServer.response.
                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }

        public async static void StartTCPListener()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 27000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    // Loop to receive all the data sent by the client.

                    Int32 count = 256;

                    byte[] bytes = new byte[count];

                    await stream.ReadAsync(bytes, 0, count);

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes("File succesfull send");

                    data = System.Text.Encoding.ASCII.GetString(bytes);

                    Controller.clientCommand = data.Replace("\0", string.Empty);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
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

        public async static void StartAsyncTCPListener()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 8080;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    // Loop to receive all the data sent by the client.

                    Int32 count = 256;

                    byte[] result = new byte[count];

                    await stream.ReadAsync(result, 0, count);

                    data = System.Text.Encoding.ASCII.GetString(result);

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes("File succesfull send");

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
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

        public static bool HasClientIpChangend(string uri, int id)
        {    
            string parameters = @"id=" + id.ToString();

            string result;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(uri, parameters);
                result = HtmlResult;
            }

            return !bool.Parse(result);
        }

        public static int SaveClientDataToServer(string uri, string name, string winVers)
        {
            //string uri = "http://www.swordbreacker.ch/idpa/index.php";
            string parameters = @"name=" + name + "&winVers=" + winVers;
            int myId;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(uri, parameters);
                myId = int.Parse(HtmlResult);
            }

            return myId;
        }

        public static string UpdateEntry(string uri, int id)
        {
            string parameters = @"id=" + id;
            string output;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(uri, parameters);
                output = HtmlResult;
            }

            return output;
        }
    }
}
