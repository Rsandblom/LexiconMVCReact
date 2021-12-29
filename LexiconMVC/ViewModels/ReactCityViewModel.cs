using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class ReactCityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        


        public ReactCityViewModel()
        {

        }

        public ReactCityViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
