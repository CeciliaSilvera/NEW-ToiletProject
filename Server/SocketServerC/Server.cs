using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO.Ports;
using System.IO;

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
             



        string path = "C:\\Users\\Alexander\\Desktop\\Toilet-Github\\";
            string filename = "users.txt";
            string fpath = "C:\\Users\\Alexander\\Desktop\\Toilet-Github\\users.txt";
            string replace = "C:\\Users\\Alexander\\Desktop\\Toilet-Github\\replace.txt";





            usbport.PortName = "COM6";
            usbport.BaudRate = 9600;




            try
            {
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listeningSocket.Bind(localEndPoint);
                listeningSocket.Listen(1);




                //Found a connection
                socket = listeningSocket.Accept();


                Byte[] buffer = new Byte[2];
                socket.Receive(buffer);

                String message = encoding.GetString(buffer);


                Byte[] buffer1 = new Byte[40];
                socket.Receive(buffer1);

                String user = encoding.GetString(buffer1);









                if (message == "1")
                {



                    List<String> list = File.ReadAllLines(path + filename).ToList();
                    {
                        if (!list.Contains(user))

                        {
                            
                            list.Add(user);

                            File.WriteAllLines(fpath, list);
                            
                            




                        }
                        
                    }

                }

                string username = File.ReadLines(path + filename).First();
                List<String> file = File.ReadAllLines(path + filename).ToList();
                { 

if(file.Contains(user))
                    {
                        counter = file.Count;
                    }

                }
                counter = counter - 1;

                Console.WriteLine("you are number " + counter + " in the queue");



                if (user == username)
                {
                    usbport.Open();
                    
                        usbport.Write(message);
                    
                    usbport.Close();

                    Console.WriteLine("light turn on message:  " + message);
                    Console.WriteLine("username:  " + user);
                }

                else
                
                    Console.WriteLine("Occupied");
                


                if (message == "2" && user == username)
                {
                    var lines = File.ReadAllLines(path + filename);
                    File.WriteAllLines(fpath, lines.Skip(1).ToArray());
                 
                  

                }
                if (message == "2" && user != username)
                {
                    string line = null;
                    string line_to_delete = user;

                    using (StreamReader reader = new StreamReader(fpath))
                    {
                        using (StreamWriter writer = new StreamWriter(replace))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (String.Compare(line, line_to_delete) == 0)
                                    continue;

                                writer.WriteLine(line);
                            }
                        }
                    }
                    using (StreamReader reader = new StreamReader(replace))
                    {
                        using (StreamWriter writer = new StreamWriter(fpath))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                

                                writer.WriteLine(line);
                            }
                        }
                    }

                }
                


                Byte[] bufferOut = encoding.GetBytes(counter.ToString());

                socket.Send(bufferOut);

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
        public char username { get; set; }
        public int counter { get; set; }

    }
}


