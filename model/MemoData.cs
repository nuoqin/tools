using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.model
{
    public class MemoData
    {
		private ObservableCollection<Memo> list;

		public ObservableCollection<Memo> List
		{
			get { return list; }
			set { list = value;  }
		}

	}
}
