using LexiconMVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Services
{
    public static class PeopleRepo
    {
        public static List<Person> peopleList;

        static PeopleRepo()
        {
            peopleList = CreatePeopleList();
        }
        private static List<Person> CreatePeopleList()
        {
            List<Person> cvItemsList = new List<Person>()
            {
                new Person( 1, "Adam Adamsson", "031-123456", 1),
                new Person( 2, "Bertil Bertilsson", "040-123456", 2),
                new Person( 3, "Carl Carlsson", "08-123456", 3),
                new Person( 4, "Dan Danielsson", "031-223456", 1),
                new Person( 5, "Erik Eriksson", "040-223456", 2),
                new Person( 6, "Frans Fransson", "08-223456", 3),
                new Person( 7, "Gustav Gustavsson", "031-323456", 1),
                new Person( 8, "Henrik Henriksson", "040-323456", 2),
                new Person( 9, "Ivar Ivarsson", "08-323456", 3),
                new Person( 10, "Jan Jansson", "031-423456", 4),
                new Person( 11, "Karl Karlsson", "040-423456", 5),
                new Person( 12, "Lars Larsson", "08-423456", 6)

            };
            return cvItemsList;

        }

        public static bool DeletePersonFromList(int id)
        {
            var item = peopleList.SingleOrDefault (p => p.Id == id);
            if (item != null)
            {
                peopleList.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddNewPersonToList(string name, string phoneNumber, int cityId)
        {
            int newId = peopleList[peopleList.Count - 1].Id;
            peopleList.Add(new Person(++newId, name, phoneNumber, cityId));
        }
    }
}
