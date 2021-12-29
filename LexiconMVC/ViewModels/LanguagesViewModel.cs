using LexiconMVCData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class LanguagesViewModel
    {
        [Display (Name="Person name")]
        public string PersonName { get; set; }
        [Display (Name ="Language")]
        public string LanguageName { get; set; }
        public List<LanguagesWithPersons> LanguagesWithPersonsList { get; set; }



        public string LanguageIdString { get; set; }

        private List<SelectListItem> _languages;
        public List<SelectListItem> Languages { get => _languages; }

        public void CreateLanguagesSelectList(List<Language> languageList)
        {
            List<SelectListItem> languagesSelectList = new List<SelectListItem>();
            foreach (var language in languageList)
            {
                languagesSelectList.Add(new SelectListItem { Value = language.Id.ToString(), Text = language.Name });
            }
            _languages = languagesSelectList;
        }

    }
}
