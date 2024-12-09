using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.common.model
{
    public class WifiEntity
    {



		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string ssid;

		public string Ssid
		{
			get { return ssid; }
			set { ssid = value; }
		}

		private string type;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		private string hight;

        public WifiEntity(string name, string ssid, string type, string hight)
        {
            this.name = name;
            this.ssid = ssid;
            this.type = type;
            this.hight = hight;
        }

        public string Hight
		{
			get { return hight; }
			set { hight = value; }
		}

	}
}
