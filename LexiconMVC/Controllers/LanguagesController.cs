using LexiconMVCData.Data;
using LexiconMVCData.Models;
using LexiconMVCData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LexiconMVCData.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly LexiconMVCDbContext _context;

        public LanguagesController(LexiconMVCDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var languagesWithPersons = _context.Languages.Include(pl => pl.PersonLanguages)
                .ThenInclude(p => p.Person).ToList();

            LanguagesViewModel languagesVM = new LanguagesViewModel();
            languagesVM.CreateLanguagesSelectList(languagesWithPersons);
            languagesVM.LanguageIdString = "1";

            List<LanguagesWithPersons> languagesWithPersonsList = new List<LanguagesWithPersons>();

            foreach (var item in languagesWithPersons)
            {
                var languagesPerson = item.PersonLanguages.Select(l => l.Person).ToList();
                languagesWithPersonsList.Add(new LanguagesWithPersons(item.Id, item.Name,languagesPerson));
            }

            languagesVM.LanguagesWithPersonsList = languagesWithPersonsList;

            return View(languagesVM);
        }

        [HttpPost]
        public ActionResult Create(LanguagesViewModel languagesVM)
        {
            var person = _context.People.Where(p => p.Name == languagesVM.PersonName).FirstOrDefault();
            var language = _context.Languages.Where(l => l.Id == Int32.Parse(languagesVM.LanguageIdString)).Include(pl => pl.PersonLanguages).FirstOrDefault();

            if (person != null && language != null)
            {
                language.PersonLanguages.Add(new PersonLanguage { PersonId = person.Id });
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }


        
    }
}
