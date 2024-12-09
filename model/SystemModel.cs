using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class SystemModel
    {

        public SystemModel(string text, string commond)
        {
            this.Text = text;
            this.Commond = commond;
        }

        public string Text { get; set; }
        
        
        public string Commond { get; set; }


    }
}
