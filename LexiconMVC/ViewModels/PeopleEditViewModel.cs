using LexiconMVCData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class PeopleEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Phone-number")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [Required]
        public string CityIdString { get; set; }

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
