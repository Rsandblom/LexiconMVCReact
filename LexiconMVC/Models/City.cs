using System.Collections.Generic;

namespace LexiconMVCData.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }


        public City()
        {

        }
    }
}