using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO.Ports;

namespace SocketServerC
{
    class Server
    {
        static UnicodeEncoding encoding = new UnicodeEncoding();
        static Socket listeningSocket = null;
        static Socket socket = null;
        const Int32 BUFFERLENGTH = 40;

        public void SocketServer(string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            SerialPort usbport = new SerialPort();

            usbport.PortName = "COM3";
            usbport.BaudRate = 9600;

            

                try
                {
                    listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    listeningSocket.Bind(localEndPoint);
                    listeningSocket.Listen(1);

                    //Found a connection
                    socket = listeningSocket.Accept();


                    Byte[] buffer = new Byte[40];
                    socket.Receive(buffer);

                    String message = encoding.GetString(buffer);



                    usbport.Open();
                    if (usbport.IsOpen)
                    {
                    
                        usbport.Write(message);
                    }
                    usbport.Close();
                Console.WriteLine(message);

                listeningSocket.Close();
                socket.Close();

                SocketServer("10.42.104.192", 8145);

                Console.ReadLine();





                }

                catch (Exception exception)
                {
                    Console.WriteLine("ERROR: " + exception.Message + "\n" + exception.StackTrace);
                    Console.ReadLine();
                }
                

            }
        }
    }


