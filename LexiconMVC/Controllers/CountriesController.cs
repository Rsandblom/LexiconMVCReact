using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LexiconMVCData.Data;
using LexiconMVCData.Models;
using LexiconMVCData.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LexiconMVCData.Controllers
{
    [Authorize(Roles = "Admin, Super Admin")]
    public class CountriesController : Controller
    {
        private readonly LexiconMVCDbContext _context;

        public CountriesController(LexiconMVCDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            CountriesViewModel countriesVM = new CountriesViewModel();
            var countryList = _context.Countries.Include(c => c.Cities).ToList();
            List<CountriesViewModelItem> countriesVMItemList = new List<CountriesViewModelItem>();

            if (countryList.Count > 0)
            {
                foreach (var item in countryList)
                {
                    CountriesViewModelItem countriesVMItem = new CountriesViewModelItem(item);
                    countriesVMItemList.Add(countriesVMItem);
                }
            }
            countriesVM.CountriesViewModelItemsList = countriesVMItemList;

            return View(countriesVM);
        }

        [HttpPost]
        public ActionResult Create(CountriesViewModel countriesVM)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(new Country { Name = countriesVM.Name });
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var country = _context.Countries.Find(id);
            _context.Remove(country);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        public ActionResult Edit(int id, Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(country);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

    }
}
