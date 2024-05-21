using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NET.Entity
{
    internal class Computers
    {
        public int code { get; set; }
        public string username { get; set; }
        public string timestart { get; set; }
        public bool Isavailable { get; set; }

        public Computers() { }
    }
}
