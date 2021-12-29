using LexiconMVCData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class CitiesViewModel
    {
        [Display(Name = "City name")]
        public string Name { get; set; }



        [Display(Name = "Country")]
        [Required]
        public string CountryIdString { get; set; }
        public List<CitiesViewModelItem> CitiesViewModelItemsList { get; set; }

        private List<SelectListItem> _countries;
        public List<SelectListItem> Countries { get => _countries; }

        public void CreateCountriesSelectList(List<Country> countryList)
        {
            List<SelectListItem> countriesSelectList = new List<SelectListItem>();
            foreach (var country in countryList)
            {
                countriesSelectList.Add(new SelectListItem { Value = country.Id.ToString(), Text = country.Name });
            }
            _countries = countriesSelectList;
        }

    }
}
