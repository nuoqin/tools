using Wpf.Ui.Controls;

namespace nuoqin.src.entity
{
    public class SystemTool
    {

        private SymbolRegular icon;

        public SymbolRegular Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string commond;

        public string Commond
        {
            get { return commond; }
            set { commond = value; }
        }

        public SystemTool(SymbolRegular icon, string title, string description, string commond)
        {
            this.icon = icon;
            this.title = title;
            this.description = description;
            this.commond = commond;
        }
    }
}
