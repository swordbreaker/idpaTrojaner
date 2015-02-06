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
        private const int port = 8080;

        //Returns the Local IP
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

        //Send a File to the Client
        public static void SendFileToClient(string server, string filePath)
        {
            try
            {
                // Create a TcpClient.
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                byte[] data = new byte[File.ReadAllBytes(filePath).Length];
                byte[] response = new Byte[256];
                data = File.ReadAllBytes(filePath);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                byte[] count = System.Text.Encoding.ASCII.GetBytes(data.Length.ToString());

                Console.WriteLine("Send File Length");

                stream.Write(count, 0, count.Length);
                // Send the message to the connected TcpServer. 

                response = new byte[256];
                Console.WriteLine("Wait for Response");

                stream.Read(response, 0, response.Length);
                Console.WriteLine("Response: " + System.Text.Encoding.ASCII.GetString(response));

                stream.Write(data, 0, data.Length);
                Console.WriteLine("Send File");
                    
                response = new byte[1];
                Console.WriteLine("Wait for Response");
                // Read the first batch of the TcpServer response bytes.

                stream.Read(response, 0, response.Length);

                if (response[response.Length - 1] == data[data.Length - 1])
                {
                    Console.WriteLine("Hash code identical 1");
                    try
                    {
                        stream.Write(System.Text.Encoding.ASCII.GetBytes("true"), 0, System.Text.Encoding.ASCII.GetBytes("true").Length);
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                    }
                    finally
                    {
                        Console.WriteLine("Hash code identical");
                    }
                }
                else
                {
                    Console.WriteLine("Hash code not identical 1");
                    stream.Write(System.Text.Encoding.ASCII.GetBytes("false"), 0, System.Text.Encoding.ASCII.GetBytes("false").Length);
                }

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
        }

        //Starts a TCP Listener
        public async static void StartTCPListener()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 27000;
                //IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(IPAddress.Any, port);

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

        //Check if the Ip has changed since last update on the Web Server
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

        //Save the Data to the Web Sever
        public static int SaveClientDataToServer(string uri, string name, string winVers)
        {
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

        //Update the Data on the Web Server
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
