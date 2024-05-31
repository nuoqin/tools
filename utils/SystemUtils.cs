using code_tools.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace code_tools.utils
{
    public class SystemUtils
    {

        public static string ping(string ips)
        {
            string data = "";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            string ip = ips+"\n\r";
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(ips,32,buffer);
            if (pingReply.Status == IPStatus.Success)
            {
                ip += "来自主机地址：" + pingReply.Address.ToString() + "\n";
                ip += "往返时间：" + pingReply.RoundtripTime.ToString() + "\n";
                ip += "生存时间：" + pingReply.Options.Ttl.ToString() + "\n";
                ip += "是否控制数据包的分段：" + pingReply.Options.DontFragment.ToString() + "\n";
                ip += "缓冲区大小：" + pingReply.Buffer.Length.ToString() + "\n\r";

                ip += "Success";
            } else{
                ip = ips + "不在线";
            }
            return ip;
        }


        public static string getLocalIP() {
            var ips = findIPs();
            string ip = "";
            foreach (IpRange ipRange in ips) {
                ip+= ipRange.CurrentAddress.ToString()+ "\n\r";
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
                var net= curIp.Substring(0, curIp.LastIndexOf(".")+1);
                var allIp = "";
                allIp +="网段 "+ net + "0 : ";
                string data = "";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                List<Task> tasks = new List<Task>();

                for (int i = 2; i < 256; i++) {
                    var netStr = net + i;
                    tasks.Add(Task.Run(() => {
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
                    //忽略非IP4的地址
                    if (addressInfo.Address.AddressFamily != AddressFamily.InterNetwork) continue;
                    var currentAddress = getCurrentIp(addressInfo.Address);
                    ips.Add(new IpRange( currentAddress));
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
            if (netInterface.NetworkInterfaceType != NetworkInterfaceType.Wireless80211)
            {
                //忽略默认网关地址为空的适配器
                var dhcpServerAddresses = ipProps.DhcpServerAddresses;
                if (dhcpServerAddresses.Count == 0)
                    ipProps = null;
            }
            return ipProps;
        }

        /**
         * 获取CPU信息
         */
        private string getCpuInfo()
        {
            ManagementClass mcCPU = new ManagementClass("Win32_Processor");
            ManagementObjectCollection mocCPU = mcCPU.GetInstances();
            foreach (ManagementObject m in mocCPU)
            {
                return m["Name"].ToString();
            }
            return "";
        }

        /**
         * 获取当前系统信息 
         */
        private string getSystemInfo(){
            ManagementClass manag = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection managCollection = manag.GetInstances();
            foreach (ManagementObject m in managCollection) {

                return m["Name"].ToString().Split('|')[0];
            }
            return "";
        }

        /**
         * 获取系统内存 
         */
        private string getMemoryInfo()
        {
            ManagementClass manag = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection managCollection = manag.GetInstances();
            foreach (ManagementObject m in managCollection)
            {

                return m["Name"].ToString().Split('|')[0];
            }
            return "";
        }
    }
}
