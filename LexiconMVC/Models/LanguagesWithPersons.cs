using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Models
{
    public class LanguagesWithPersons
    {
        public int Id { get; set; }
        [Display(Name = "Language")]
        public string Name { get; set; }
        [Display(Name = "People")]
        public List<Person> People { get; set; }

        public LanguagesWithPersons(int id, string name, List<Person> people)
        {
            Id = id;
            Name = name;
            People = people;
        }
    }
}
