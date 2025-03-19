using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuoqin.src.entity
{
    public class CutstomHttpEntity
    {
        public CutstomHttpEntity()
        {
        }

        public CutstomHttpEntity(string url, List<Dictionary<string, string>> headers, List<Dictionary<string, object>> param,string body)
        {
            this.url = url;
            this.headers = headers;
            this.param = param;
            this.body = body;
        }

        private string url;

		public string Url
		{
			get { return url; }
			set { url = value; }
		}

        private List<Dictionary<string, string>> headers;

        public List<Dictionary<string, string>> Headers
        {
            get { return headers; }
            set { headers = value; }
        }

        private List<Dictionary<string, object>> param;

        public List<Dictionary<string, object>> Param
        {
            get { return param; }
            set { param = value; }
        }

        private string body;

        

        public string Body
        {
            get { return body; }
            set { body = value; }
        }


    }
}
