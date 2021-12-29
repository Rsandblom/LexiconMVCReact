using LexiconMVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class CountriesViewModelItem
    {
        public int Id { get; set; }
        [Display(Name = "Country name")]
        public string Name { get; set; }
        [Display(Name = "Cities")]
        public List<City> Cities { get; set; }
        public CountriesViewModelItem(Country country)
        {
            Id = country.Id;
            Name = country.Name;
            Cities = country.Cities;
        }
    }
}
