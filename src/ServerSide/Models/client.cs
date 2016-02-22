using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ToiletProject
{
    class client
    {
        public void SendMessage(string Message, string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, port);
            UnicodeEncoding encoding = new UnicodeEncoding();
            Socket socket = null;
            



            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEndPoint);

                //encode from a string format to bytes ("our packages")



                Byte[] bufferOut = encoding.GetBytes(Message);



                socket.Send(bufferOut);
                



                socket.Close();


            }
            catch (Exception)
            {

                    throw;
            }
        }
        
    }
}
