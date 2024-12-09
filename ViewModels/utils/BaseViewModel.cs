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
    public class BaseViewModel : NavigationViewModel
    {
        public BaseViewModel(IContainerProvider containerProvider) : base(containerProvider)
        {
        }





    }
}
