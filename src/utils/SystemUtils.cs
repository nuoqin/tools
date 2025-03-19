using nuoqin.src.entity;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace code_tools.utils
{
    public class SystemUtils
    {

        public static string ping(string ips)
        {
            string data = "";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            string ip = ips + "\n\r";
            Ping ping = new Ping();
            for (int i = 0; i < 4; i++)
            {
                PingReply pingReply = ping.Send(ips, 32, buffer);
                if (pingReply.Status == IPStatus.Success)
                {
                    if (i == 0)
                    {
                        ip += "正在Ping:" + ips + "【" + pingReply.Address.ToString() + "】 具有 32 字节的数据:\n";
                    }
                    ip += "来自：" + pingReply.Address.ToString() + " 的回复:  ";
                    ip += "字节=32 ";
                    ip += "时间=" + pingReply.RoundtripTime.ToString() + " ";
                    ip += "TTL=" + pingReply.Options.Ttl.ToString() + "ms\n";
                    if (i == 3)
                    {
                        ip += "Success";
                    }
                }
                else
                {
                    ip = ips + "不在线";
                }
            }

            return ip;
        }


        public static string getLocalIP()
        {
            var ips = findIPs();
            string ip = "";
            foreach (IpRange ipRange in ips)
            {
                ip += ipRange.CurrentAddress.ToString() + "\n\r";
            }
            return ip;
        }


        public static string getCurLocalNetIPs()
        {
            var ips = findIPs();
            string ip = "";
            foreach (IpRange ipRange in ips)
            {
                var curIp = ipRange.CurrentAddress.ToString();
                var net = curIp.Substring(0, curIp.LastIndexOf(".") + 1);
                var allIp = "";
                allIp += "网段 " + net + "0 : ";
                string data = "";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                List<Task> tasks = new List<Task>();
                for (int i = 2; i < 256; i++)
                {
                    var netStr = net + i;
                    tasks.Add(Task.Run(() =>
                    {
                        Ping ping = new Ping();
                        PingReply pingReply = ping.Send(netStr, 32, buffer);
                        //netStr += "";
                        if (pingReply.Status == IPStatus.Success)
                        {
                            allIp += netStr + "; ";
                        }
                    }));
                }
                Task.WaitAll(tasks.ToArray());
                ip += allIp + "\r\n";
            }
            return ip;
        }





        public static List<IpRange> findIPs()
        {

            NetworkInterface[] netInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            List<IpRange> ips = new List<IpRange>();
            foreach (NetworkInterface netInterface in netInterfaces)
            {
                var prop = getIpInterfaceProperties(netInterface);
                if (prop == null) continue;
                foreach (var addressInfo in prop.UnicastAddresses)
                {
                    if (addressInfo.Address.ToString() != null) new IPAddress(addressInfo.Address.GetAddressBytes());
                    //忽略非IP4的地址
                    if (addressInfo.Address.AddressFamily != AddressFamily.InterNetwork) continue;
                    var currentAddress = getCurrentIp(addressInfo.Address);
                    ips.Add(new IpRange(currentAddress));
                }
            }

            return ips;
        }

        private static IPAddress getCurrentIp(IPAddress address)
        {
            byte[] addressBytes = address.GetAddressBytes();
            return new IPAddress(addressBytes);
        }

        private static IPInterfaceProperties getIpInterfaceProperties(NetworkInterface netInterface)
        {
            IPInterfaceProperties ipProps = null;
            if (netInterface.OperationalStatus != OperationalStatus.Up) return null;
            ipProps = netInterface.GetIPProperties();
            if (netInterface.NetworkInterfaceType != NetworkInterfaceType.Wireless80211 || netInterface.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
            {
                //忽略默认网关地址为空的适配器
                var dhcpServerAddresses = ipProps.DhcpServerAddresses;
                if (dhcpServerAddresses.Count == 0)
                    ipProps = null;
            }
            return ipProps;
        }
    }
}
