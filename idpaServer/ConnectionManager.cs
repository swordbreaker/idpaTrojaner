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
        public static void Main(string[] args)
        {
            Console.Write("Message: ");
            string msg = Console.ReadLine();

            Connect("127.0.0.1", msg);
            //// Establish the local endpoint for the socket.
            //IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAddr = ipHost.AddressList[6];
            ////IPAddress ipAddr = IPAddress.Parse("192.168.178.22");
            //IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            //Console.WriteLine(ipHost.AddressList.Length);
            //Console.WriteLine(ipAddr);
            //Console.WriteLine(ipEndPoint);

            //// Create a TCP socket.
            //Socket client = new Socket(AddressFamily.InterNetwork,
            //        SocketType.Stream, ProtocolType.Tcp);

            //// Connect the socket to the remote endpoint.
            //client.Connect(ipEndPoint);

            //// There is a text file test.txt located in the root directory. 
            //string fileName = @"C:\test.txt";

            //// Send file fileName to remote device
            //Console.WriteLine("Sending {0} to the host.", fileName);
            //client.SendFile(fileName);

            //// Release the socket.
            //client.Shutdown(SocketShutdown.Both);
            //client.Close();
        }

        static void Connect(String server, String message)
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
                //Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                //Byte[] data = File.ReadAllBytes(@"C:\Temp\log.xml");
                List<Byte> data = new List<Byte>();
                data.AddRange(File.ReadAllBytes(@"C:\Temp\log.xml"));

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data.ToArray(), 0, data.Count);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                //data = new Byte[256];
                data = new List<Byte>();

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data.ToArray(), 0, data.Count);
                responseData = System.Text.Encoding.ASCII.GetString(data.ToArray(), 0, bytes);
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

    }
}
