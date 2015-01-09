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
            //saveClientDataToServer("http://www.swordbreacker.ch/idpa/index.php", "testName", "Windows Blabla");

            Console.WriteLine(HasClientIpChangend("http://www.swordbreacker.ch/idpa/getip.php", 37));
            

            string msg = Console.ReadLine();

            Connect("127.0.0.1", msg);
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

                byte[] data = new byte[File.ReadAllBytes(@"C:\Temp\log.xml").Length];
                data = File.ReadAllBytes(@"C:\Temp\log.xml");

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                Console.WriteLine();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

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

            return bool.Parse(result);
        }

        public static string saveClientDataToServer(string uri, string name, string winVers)
        {
            //string uri = "http://www.swordbreacker.ch/idpa/index.php";
            string parameters = @"name=" + name + "&winVers=" + winVers;
            string myId;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(uri, parameters);
                myId = HtmlResult;
            }
            return myId;
        }
    }
}
