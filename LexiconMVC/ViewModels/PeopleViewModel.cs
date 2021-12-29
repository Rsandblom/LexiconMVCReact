using LexiconMVCData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class PeopleViewModel
    {
        public CreatePersonViewModel CreatePerson { get; set; }
        public List<Person> PeopleList { get; set; }
        [Display(Name ="Search")]
        public string SearchString { get; set; }

        public string SortOrder { get; set; }
        [Display(Name ="Name")]
        public string SortByName { get; set; }
        [Display(Name = "City")]
        public string SortByCity { get; set; }

        private List<SelectListItem> _cities;
        public List<SelectListItem> Citites { get => _cities; }

        public void CreateCitiesSelectList(List<City> cityList)
        {
            List<SelectListItem> citiesSelectList = new List<SelectListItem>();
            foreach (var city in cityList)
            {
                citiesSelectList.Add(new SelectListItem { Value = city.Id.ToString(), Text = city.Name });
            }
            _cities = citiesSelectList;
        }



    }
}
