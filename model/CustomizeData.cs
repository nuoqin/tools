using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.model
{
    public class CustomizeData
    {
		private ObservableCollection<CustomizeFunction> list;

		public ObservableCollection<CustomizeFunction> List
		{
			get { return list; }
			set { list = value;  }
		}

	}
}
