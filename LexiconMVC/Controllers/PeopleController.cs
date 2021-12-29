using LexiconMVCData.Data;
using LexiconMVCData.Models;
using LexiconMVCData.Services;
using LexiconMVCData.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Controllers
{
    //[Authorize(Roles = "RegUser,Admin, Super Admin")]
    public class PeopleController : Controller
    {
        private readonly LexiconMVCDbContext _context;

        public PeopleController(LexiconMVCDbContext context)
        {
            _context = context;
        }
        
        public ActionResult Index(PeopleViewModel pVM)
        {
            PeopleViewModel peopleVM = new PeopleViewModel();
            peopleVM.CreateCitiesSelectList(_context.Cities.ToList());
            peopleVM.PeopleList = _context.People.Include(p => p.City).ToList();
            peopleVM.SortByName = String.IsNullOrEmpty(pVM.SortOrder) ? "name_desc" : "";
            peopleVM.SortByCity = pVM.SortOrder == "city" ? "city_desc" : "city";

            if (!String.IsNullOrEmpty(pVM.SearchString))
            {
                peopleVM.PeopleList = peopleVM.PeopleList.Where(c => c.City.Name!.Contains(pVM.SearchString) || c.Name!.Contains(pVM.SearchString)).ToList();

            }

            switch (pVM.SortOrder)
            {
                case "name_desc":
                    peopleVM.PeopleList = peopleVM.PeopleList.OrderByDescending(p => p.Name).ToList();
                    break;
                case "city":
                    peopleVM.PeopleList = peopleVM.PeopleList.OrderBy(p => p.City.Name).ToList();
                    break;
                case "city_desc":
                    peopleVM.PeopleList = peopleVM.PeopleList.OrderByDescending(p => p.City.Name).ToList(); ;
                    break;
                default:
                    peopleVM.PeopleList = peopleVM.PeopleList.OrderBy(p => p.Id).ToList(); ;
                    break;
            }

            return View(peopleVM);
        }

     
        [HttpPost]
        public ActionResult Create(PeopleViewModel peopleVM)
        {
            if (ModelState.IsValid)
            {
                var city = _context.Cities.Where(c => c.Id == Int32.Parse(peopleVM.CreatePerson.CityIdString)).FirstOrDefault();
                Person person = new Person { Name = peopleVM.CreatePerson.Name, PhoneNumber = peopleVM.CreatePerson.PhoneNumber, CityId = city.Id };
                _context.People.Add(person);
                _context.SaveChanges();
                city.People.Add(person);
                _context.SaveChanges();

            }
            
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin, Super Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var person = _context.People.Find(id);
            _context.Remove(person);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.People.Where(p => p.Id == id).Include(p => p.City).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }

            PeopleEditViewModel peopleEditVM = new PeopleEditViewModel { Id = person.Id, Name = person.Name, PhoneNumber = person.PhoneNumber, CityIdString = person.City.Id.ToString() };
            peopleEditVM.CreateCitiesSelectList(_context.Cities.ToList());
            return View(peopleEditVM);
        }
        
        
        [HttpPost]
        public ActionResult Edit(int id, PeopleEditViewModel peopleEditViewModel)
        {
            if (id != peopleEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var city = _context.Cities.Where(c => c.Id == Int32.Parse(peopleEditViewModel.CityIdString)).FirstOrDefault();
                var person = _context.People.Find(id);
                person.City = city;
                person.CityId = city.Id;
                _context.Update(person);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(peopleEditViewModel);
        }


    }
}
