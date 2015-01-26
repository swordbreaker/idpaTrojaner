using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IdpaClient
{
    class ConnectionManager
    {
        private static Stopwatch stopWatch = new Stopwatch();

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
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 27000;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                byte[] data = new byte[System.Text.Encoding.ASCII.GetBytes(message).Length];
                data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();


                stream.Write(data, 0, data.Length);

                // Send the message to the connected TcpServer. 
                //await stream.WriteAsync(data, 0, data.Length);
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

        public static async Task<double> Ping(string server)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 27000;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                byte[] data = new byte[System.Text.Encoding.ASCII.GetBytes("ping").Length];
                data = System.Text.Encoding.ASCII.GetBytes("ping");

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                stopWatch.Restart();
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                //stream.Write(data, 0, data.Length);

                // Receive the TcpServer.response.
                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                stopWatch.Stop();

                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();

                return stopWatch.Elapsed.TotalMilliseconds;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                return -1;
            }
            catch
            {
                //Console.WriteLine("SocketException: {0}", e);
                return -1;
            }
        }

        //public static void startTCPListener()
        //{
        //    TcpListener server = null;
        //    try
        //    {
        //        // Set the TcpListener on port 13000.
        //        Int32 port = 8080;
        //        IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        //        // TcpListener server = new TcpListener(port);
        //        server = new TcpListener(localAddr, port);

        //        // Start listening for client requests.
        //        server.Start();

        //        // Buffer for reading data
        //        //Byte[] bytes = new Byte[256];
        //        List<Byte> bytes = new List<byte>();
        //        String data = null;

        //        // Enter the listening loop.
        //        while (true)
        //        {
        //            Console.Write("Waiting for a connection... ");

        //            // Perform a blocking call to accept requests.
        //            // You could also user server.AcceptSocket() here.
        //            TcpClient client = server.AcceptTcpClient();
        //            Console.WriteLine("Connected!");

        //            data = null;

        //            // Get a stream object for reading and writing
        //            NetworkStream stream = client.GetStream();

        //            int i;

        //            // Loop to receive all the data sent by the client.
        //            while ((i = stream.Read(bytes.ToArray(), 0, 256)) != 0)
        //            {
        //                // Translate data bytes to a ASCII string.
        //                data = System.Text.Encoding.ASCII.GetString(bytes.ToArray(), 0, i);
        //                Console.WriteLine("Received: {0}", data);

        //                // Process the data sent by the client.
        //                data = data.ToUpper();

        //                Byte[] fileData = System.Text.Encoding.ASCII.GetBytes(data.ToArray());
        //                data = System.Text.Encoding.ASCII.GetString(fileData);

        //                FileManager.CreateFile(@"C:\Temp\log_send.xml");
        //                FileManager.SaveLogFile(data, @"C:\Temp\log_send.xml");

        //                Console.WriteLine("Sent: {0}", data);
        //                Console.WriteLine("Penis");
        //            }

        //            byte[] msg = System.Text.Encoding.ASCII.GetBytes("File succesfull send");

        //            // Send back a response.
        //            stream.Write(msg, 0, msg.Length);


        //            // Shutdown and end connection
        //            client.Close();
        //        }
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine("SocketException: {0}", e);
        //    }
        //    finally
        //    {
        //        // Stop listening for new clients.
        //        server.Stop();
        //    }
        //    Console.WriteLine("\nHit enter to continue...");
        //    Console.Read();
        //}

        public async static Task startAsyncTCPListener(int fileId)
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

                Int32 count = 50000;

                byte[] result;
                result = new byte[count];

                await stream.ReadAsync(result, 0, count);

                data = System.Text.Encoding.ASCII.GetString(result);
                count = int.Parse(data);
                result = new byte[count];

                // Loop to receive all the data sent by the client.

                await stream.ReadAsync(result, 0, count);

                if (fileId == 1)
                    Form1.storeLogFile(result);
                else
                    Form1.storeData(result);

                byte[] msg = System.Text.Encoding.ASCII.GetBytes("File succesfull send");

                // Send back a response.
                stream.Write(msg, 0, msg.Length);

                // Shutdown and end connection
                client.Close();
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
        }
    }
}
