using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.common.model
{
    public class ItemData : BindableBase
    {
        private string title;

        private string color;

        private string icon;

        private string nameSpace;

        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }


        public string NameSpace
        {
            get { return nameSpace; }
            set { nameSpace = value; }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public string Title
        {
            get { return title; }
            set { title = value; }
        }


    }
}
