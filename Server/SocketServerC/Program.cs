﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerC
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.SocketServer("10.42.105.46", 8145);

        }
    }
}
