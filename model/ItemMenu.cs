using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace code_tools.model
{
    public class ItemMenu
    {
        public ItemMenu(string header, List<SubItem> subItems)
        {
            Header = header;
            SubItems = subItems;
        }

        public ItemMenu(string header, UserControl sc)
        {
            Header = header;
            Screen = sc;
        }

        public string Header { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }
    }
}
