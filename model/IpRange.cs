using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace code_tools.model
{
    public class IpRange
    {
      

        public IPAddress CurrentAddress { get; }

        public IpRange(IPAddress iPAddress)
        {
            
            CurrentAddress = iPAddress;
        }
    }
}
