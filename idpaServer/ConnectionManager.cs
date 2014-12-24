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
            // Establish the local endpoint for the socket.
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[6];
            //IPAddress ipAddr = IPAddress.Parse("192.168.178.22");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            Console.WriteLine(ipHost.AddressList.Length);
            Console.WriteLine(ipAddr);
            Console.WriteLine(ipEndPoint);

            // Create a TCP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint.
            client.Connect(ipEndPoint);

            // There is a text file test.txt located in the root directory. 
            string fileName = "C:\\test.txt";

            // Send file fileName to remote device
            Console.WriteLine("Sending {0} to the host.", fileName);
            client.SendFile(fileName);

            // Release the socket.
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
