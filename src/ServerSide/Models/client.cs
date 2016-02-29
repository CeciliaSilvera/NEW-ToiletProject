using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToiletProject.Models.ViewModels;
using Microsoft.AspNet.Authorization;
using System.IO;

namespace ToiletProject
{
    class client
    {
        public void SendMessage(string Message, string user, string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, port);
            UnicodeEncoding encoding = new UnicodeEncoding();
            Socket socket = null;
            string path = "C:\\Users\\Alexander\\Desktop\\Toilet-Github\\qNumber.txt";



            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEndPoint);

                //encode from a string format to bytes ("our packages")



                Byte[] bufferOut = encoding.GetBytes(Message);
                Byte[] bufferOut1 = encoding.GetBytes(user);





                socket.Send(bufferOut);
                socket.Send(bufferOut1);



                Byte[] buffer = new Byte[8];
                socket.Receive(buffer);
                String qNumber = encoding.GetString(buffer);
                string compare = File.ReadAllLines(path).ToString();
                //compare = 0+compare;               
                qNumber = 0+qNumber;
                //if (qNumber != compare)
                //{
                //    qNumberint = Int32.Parse(qNumber);
                //    qNumber = qNumberint--.ToString();
                //}
                File.WriteAllText(path, qNumber);
                    


                socket.Close();
                

            }
            catch (Exception)
            {

                    throw;
            }
        }
        
    }
}
