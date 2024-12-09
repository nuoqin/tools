using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.common.model
{
    public class Menubar : BindableBase
    {
        private string icon;

        private string title;

        private string nameSpace;

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public string Icon { get { return icon; } set {  icon = value; } }


        public string Title { get { return title;} set { title = value; } }

        public string NameSpace { get {  return nameSpace; } set {  nameSpace = value; } }
    }
}
