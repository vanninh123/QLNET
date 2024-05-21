using FireSharp.Response;
using QL_NET.Entity;
using QL_NET.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QL_NET
{
    internal  class SharedVariable
    { 
        public static int giatien = 0;
        public static string username = "";
        public static int hours = 0;
        public static int minutes = 0;
        public static string id = "";
        public static int tempt = 0;
    }
}
