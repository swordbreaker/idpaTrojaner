using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdpaClient
{
    class ConnectionManager
    {
        private static Stopwatch stopWatch = new Stopwatch();
        private const int port = 12345;
        private static string localIP = "192.168.178.22";
        private static Form1 activeForm = (System.Windows.Forms.Application.OpenForms["Form1"] as Form1);

        public static string GetPcInformations(string uri)
        {
            string result;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                result = wc.DownloadString(uri);
            }
            return result;
        }

        public static bool SendCommand(string server, string message)
        {
            try
            {
                // Create a TcpClient.
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                byte[] data = new byte[System.Text.Encoding.ASCII.GetBytes(message).Length];
                data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                // Send the message to the connected TcpServer. 

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

                return true;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                return false;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return false;
            }
        }

        public static async void Ping(string server)
        {
            try
            {
                // Create a TcpClient.
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                byte[] data = new byte[System.Text.Encoding.ASCII.GetBytes("ping").Length];
                data = System.Text.Encoding.ASCII.GetBytes("ping");

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                stopWatch.Restart();
                // Send the message to the connected TcpServer. 

                await stream.WriteAsync(data, 0, data.Length);
                //stream.Write(data, 0, data.Length);
                stopWatch.Stop();

                // Close everything.
                stream.Close();
                client.Close();

                activeForm.ping = stopWatch.Elapsed.TotalMilliseconds;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                activeForm.ping = -1;
            }
            catch
            {
                activeForm.ping = -1;
            }
        }

        public async static Task startAsyncTCPListener(int fileId)
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                //IPAddress localAddr = IPAddress.Parse(localIP);

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(IPAddress.Any, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                //Byte[] bytes = new Byte[256];
                List<Byte> bytes = new List<byte>();
                String data = null;

                Console.WriteLine("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int count = 0;

                byte[] resultDataLenth;
                byte[] resultFile = new byte[0];;
                byte[] resultHash;
                resultDataLenth = new byte[256];
                resultHash = new byte[256];

                bool hashOK = false;

                //Get File Lenth
                Console.WriteLine("Read File Lenght");

                await stream.ReadAsync(resultDataLenth, 0, resultDataLenth.Length);
                    
                data = System.Text.Encoding.ASCII.GetString(resultDataLenth);
                try
                {
                    count = int.Parse(data);
                }
                catch
                {
                    count = 265;
                    Console.WriteLine("Int error");
                }

                Console.WriteLine("Count is " + count);

                resultFile = new byte[count];

                //activeForm.print("File size: " + count + " KB");
                activeForm.printMsg += "File size: " + count + " KB\n\r";

                Console.WriteLine("Write Response");
                await stream.WriteAsync(resultDataLenth, 0, resultDataLenth.Length);
                    
                Console.WriteLine("Read File");
                await stream.ReadAsync(resultFile, 0, count);
                    
                byte[] respond = new byte[1];
                respond[0] = resultFile[resultFile.Length - 1];

                // Send back a response.
                Console.WriteLine("Write Response");
                await stream.WriteAsync(respond, 0, respond.Length);
                    
                resultHash = new byte[256];

                await stream.ReadAsync(resultHash, 0, resultHash.Length);
                    
                Console.WriteLine("Read File Check");
                Console.WriteLine("File Check ist: " + System.Text.Encoding.ASCII.GetString(resultHash));

                try
                {
                    hashOK = bool.Parse(System.Text.Encoding.ASCII.GetString(resultHash));
                }
                catch
                {
                    hashOK = false;
                }

                if (!hashOK)
                {
                    //await stream.WriteAsync(resultHash, 0, resultHash.Length);
                    activeForm.printMsg += "Error accurred while downloading \n\r";
                    stream.Close();
                    client.Close();
                    server.Stop();
                    return;
                }

                if (fileId == 1)
                    activeForm.storeLogFile(resultFile);
                else
                    activeForm.storeData(resultFile);

                // Shutdown and end connection
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }
    }
}
