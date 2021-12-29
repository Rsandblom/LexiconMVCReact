using LexiconMVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class CountriesViewModel
    {
        [Display(Name = "Country name")]
        public string Name { get; set; }

        public List<CountriesViewModelItem> CountriesViewModelItemsList { get; set; }
    }
}
