using System.Net;

namespace nuoqin.src.entity
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
