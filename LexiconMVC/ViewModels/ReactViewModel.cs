using LexiconMVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class ReactViewModel
    {
        public List<ReactPersonViewModel> ReactPersonVMList { get; set; }

        public List<ReactCityViewModel> CitiesList { get; set; }
    }
}
