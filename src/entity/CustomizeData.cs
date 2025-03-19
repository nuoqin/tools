using System.Collections.ObjectModel;

namespace nuoqin.src.entity
{
    public class CustomizeData
    {
        private ObservableCollection<CustomizeFunction> list;

        public ObservableCollection<CustomizeFunction> List
        {
            get { return list; }
            set { list = value; }
        }

    }
}
