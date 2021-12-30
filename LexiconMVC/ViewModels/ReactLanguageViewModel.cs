using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class ReactLanguageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ReactLanguageViewModel()
        {

        }

        public ReactLanguageViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
