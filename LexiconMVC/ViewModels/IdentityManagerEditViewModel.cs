using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.ViewModels
{
    public class IdentityManagerEditViewModel
    {
        public string Id { get; set; }

        [Display(Name = "First name")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Role")]
        public string RoleIdString { get; set; }

        private List<SelectListItem> _roles;
        public List<SelectListItem> Roles { get => _roles; }

        public void CreateRolesSelectList(List<IdentityRole> roleList)
        {
            List<SelectListItem> rolesSelectList = new List<SelectListItem>();
            foreach (var role in roleList)
            {
                rolesSelectList.Add(new SelectListItem { Value = role.Id.ToString(), Text = role.Name });
            }
            _roles = rolesSelectList;
        }
    }
}
