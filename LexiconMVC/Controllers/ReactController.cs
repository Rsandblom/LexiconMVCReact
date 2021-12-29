using LexiconMVCData.Data;
using LexiconMVCData.Models;
using LexiconMVCData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Controllers
{
    public class ReactController : Controller
    {
        private readonly LexiconMVCDbContext _context;

        public ReactController(LexiconMVCDbContext context)
        {
            _context = context;
        }

        public string Index()
        {
            return "test";
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var peopleList = _context.People.Include(p => p.City).ToList();
            var reactPersonVMList = new List<ReactPersonViewModel>();
            foreach (var item in peopleList)
            {
                reactPersonVMList.Add(new ReactPersonViewModel(item.Id, item.Name, item.PhoneNumber, item.City.Name));
            }

            var citiesList = _context.Cities.ToList();
            var reactCityVMList = new List<ReactCityViewModel>();
            foreach (var item in citiesList)
            {
                reactCityVMList.Add(new ReactCityViewModel(item.Id, item.Name));
            }

            ReactViewModel reactVM = new ReactViewModel();
            reactVM.ReactPersonVMList = reactPersonVMList;
            reactVM.CitiesList = reactCityVMList;

            return Json(reactVM);
        }

        [HttpPost]
        public ActionResult Create(ReactPersonViewModel reactPersonVM)
        {
            if (ModelState.IsValid)
            {
                var city = _context.Cities.Where(c => c.Id == Int32.Parse(reactPersonVM.CityName)).FirstOrDefault();
                Person person = new Person { Name = reactPersonVM.Name, PhoneNumber = reactPersonVM.PhoneNumber, CityId = city.Id };
                _context.People.Add(person);
                _context.SaveChanges();
                city.People.Add(person);
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }
    }
}
