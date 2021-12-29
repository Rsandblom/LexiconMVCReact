using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }

        public Person()
        {
                
        }

        public Person(int id, string name, string phoneNumber, int cityId)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            CityId = cityId;
        }
    }
}
