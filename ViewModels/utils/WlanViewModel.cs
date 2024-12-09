using CodeTools.common.model;
using CodeTools.utils;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTools.ViewModels.utils
{
    public class WlanViewModel : NavigationViewModel
    {
        public WlanViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
            wifis = WifiUtils.getWifis();
        }

        public List<WifiEntity> wifis { get; set; }




    }
}
