using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NET.Entity
{
    internal class Items
    {
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }

            public int quantity { get; set; }
            public string url { get; set; }

            public int price { get; set; }

            public Items() { }
    }
}
