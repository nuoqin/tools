using CodeTools.common.model;
using NativeWifi;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.utils
{
    public class WifiUtils
    {

        public static List<WifiEntity> getWifis() {
            var list=new List<WifiEntity>();
            var set=new HashSet<string>();
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);

                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    var name = network.profileName;
                    var hight = network.wlanSignalQuality;
                    var daa=network.dot11DefaultAuthAlgorithm.ToString();
                    var dca=network.dot11DefaultCipherAlgorithm.ToString();
                    var ssid= Encoding.UTF8.GetString(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength);
                    string hex = string.Join("", ssid.Select(c => ((int)c).ToString("x2")));
                    if (set.Contains(ssid)) {
                        continue;
                    }
                    set.Add(ssid);
                    list.Add(new WifiEntity(name: ssid, ssid: hex, type: getWay(daa), hight: hight+""));
                }

            }

            return list;
        }

        private static string getWay(string code) {
            string auth = "";
            switch (code)
            {
                case "IEEE80211_Open":
                    auth = "open"; break;
                case "RSNA":
                    auth = "WPA2PSK"; break;
                case "RSNA_PSK":
                    auth = "WPA2PSK"; break;
                case "WPA":
                    auth = "WPAPSK"; break;
                case "WPA_None":
                    auth = "WPAPSK"; break;
                case "WPA_PSK":
                    auth = "WPAPSK"; break;
            }
            return auth;

        }

        private static string getType(string code)
        {
            string auth = "";
            switch (code)
            {
                case "CCMP":
                    auth = "AES";
                    break;
                case "TKIP":
                    auth = "TKIP";
                    break;
                case "None":
                    auth = "none"; 
                    break;
                case "WWEP":
                    auth = "WEP";
                    break;
                case "WEP40":
                    auth = "WEP";
                    break;
                case "WEP104":
                    auth = "WEP";
                    break;
            }
            return auth;

        }
    }
}
