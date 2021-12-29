using LexiconMVCData.Models;
using LexiconMVCData.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class IdentityManagerController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public IdentityManagerController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IdentityManagerViewModel identityMngVM = new IdentityManagerViewModel();
            var roles = await _roleManager.Roles.ToListAsync();
            identityMngVM.RolesList = roles;

            var users = _userManager.Users.ToList();
            var userRolesViewModelList = new List<UserWithRolesViewModel>();

            foreach (ApplicationUser user in users)
            {
                var userViewModel = new UserWithRolesViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = await GetUserRoles(user)
                };
                userRolesViewModelList.Add(userViewModel);
            }
            identityMngVM.UserWithRolesList = userRolesViewModelList;

            return View(identityMngVM);
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityManagerViewModel identityManagerViewModel)
        {
            if (identityManagerViewModel.Name != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(identityManagerViewModel.Name.Trim()));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _roleManager.Roles.ToListAsync();


            IdentityManagerEditViewModel identityMngEditVM = new IdentityManagerEditViewModel { Id = user.Id, Name = user.FirstName };
            identityMngEditVM.CreateRolesSelectList(roles);

            return View(identityMngEditVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, IdentityManagerEditViewModel identityManagerEditVM)
        {
            if (id != identityManagerEditVM.Id)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            var role = await _roleManager.FindByIdAsync(identityManagerEditVM.RoleIdString);

            if (user == null)
            {
                return View();
            }

            await _userManager.AddToRoleAsync(user, role.Name);
            
            return RedirectToAction("Index");
        }
    }
}
