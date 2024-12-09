using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.model
{
    public class Memo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; ; }
            set { userName = value; }
        }

        private string password;

        public string Password
        {
            get { return password; ; }
            set { password = value; }
        }

        private bool enable;

        public bool Enable
        {
            get { return enable;  }
            set { enable = value; }
        }


        private string title;

        public string Title
        {
            get { return title; ; }
            set { title = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }


       
    }
}
