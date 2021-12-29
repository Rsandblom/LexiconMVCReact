using LexiconMVCData.Data;
using LexiconMVCData.Models;
using LexiconMVCData.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LexiconMVCData.Controllers
{
    //[Authorize(Roles = "Admin, Super Admin")]
    public class CitiesController : Controller
    {
        private readonly LexiconMVCDbContext _context;

        public CitiesController(LexiconMVCDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            CitiesViewModel citiesVM = new CitiesViewModel();
            citiesVM.CreateCountriesSelectList(_context.Countries.ToList());
            var cityList = _context.Cities.Include(c => c.People).ToList();
            List<CitiesViewModelItem> citiesVMItemList = new List<CitiesViewModelItem>();

            if (cityList.Count > 0)
            {
                foreach (var item in cityList)
                {
                    CitiesViewModelItem citiesVMItem = new CitiesViewModelItem(item);
                    citiesVMItemList.Add(citiesVMItem);
                }
            }

            citiesVM.CitiesViewModelItemsList = citiesVMItemList;

            return View(citiesVM);
        }

        [HttpPost]
        public ActionResult Create(CitiesViewModel citiesVM)
        {
            if (ModelState.IsValid)
            {
                var country = _context.Countries.Where(c => c.Id == Int32.Parse(citiesVM.CountryIdString)).FirstOrDefault();
                City city = new City { Name = citiesVM.Name, CountryId = country.Id };
                _context.Cities.Add(city);
                _context.SaveChanges();
                country.Cities.Add(city);
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var city = _context.Cities.Find(id);
            _context.Remove(city);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(int id, City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var country = _context.Countries.Where(c => c.Id == city.CountryId).FirstOrDefault();
                city.Country = country;
                _context.Update(city);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }
    }
}
