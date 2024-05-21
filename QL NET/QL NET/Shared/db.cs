using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NET.Shared
{
    internal class db
    {
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "fvWBYF4FsszExyQ8KoHhwoImMMuJiYKTNzaJll8r",
            BasePath = "https://ql-net-2d825-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public static IFirebaseClient client = new FireSharp.FirebaseClient(config);
            
    }
}
