using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMagician
{
    static class LoginContext
    {

        public static Broker BrokerInfo { get; set; }
        public static Server ServerInfo { get; set; }

        public static String UserName { get; set; }
        public static String Password { get; set; }
    }
}
