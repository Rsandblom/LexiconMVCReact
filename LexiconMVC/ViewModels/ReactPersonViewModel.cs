using LexiconMVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class ReactPersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string CityName { get; set; }

        public List<ReactLanguageViewModel> Languages { get; set; }
        /*
        public City City { get; set; }
        public int CityId { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
        */
        public ReactPersonViewModel()
        {

        }

        public ReactPersonViewModel(int id, string name, string phoneNumber, string cityName, List<ReactLanguageViewModel> languages)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            CityName = cityName;
            Languages = languages;
        }
    }
}
