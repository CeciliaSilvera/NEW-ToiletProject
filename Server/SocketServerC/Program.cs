using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerC
{
    class Program
    {


        static void Main(string[] args)
        {
            string fpath = "C:\\Users\\Alexander\\Desktop\\Toilet-Github\\users.txt";

            string replace = "C:\\Users\\Alexander\\Desktop\\Toilet-Github\\replace.txt";


            File.Create(fpath).Close();

            File.Create(replace).Close();

            Server server = new Server();
            server.SocketServer("172.20.10.3", 8145);

        }
        
    }
}
