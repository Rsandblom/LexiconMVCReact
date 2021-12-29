using LexiconMVCData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class CitiesViewModelItem
    {
        public int Id { get; set; }
        [Display(Name = "City name")]
        public string Name { get; set; }
        [Display(Name = "People")]
        public List<Person> People { get; set; }
        public CitiesViewModelItem(City city)
        {
            Id = city.Id;
            Name = city.Name;
            People = city.People;
        }
    }
}
