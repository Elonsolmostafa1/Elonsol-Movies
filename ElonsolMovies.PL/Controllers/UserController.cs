using ElonsolMovies.BLL;
using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.DAL.Models;
using ElonsolMovies.PL.Helpers;
using ElonsolMovies.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ElonsolMovies.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager , RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var users = userManager.Users.Select(U => new UserViewModel()
                {
                    Id = U.Id,
                    UserName = U.UserName,
                    Email = U.Email,
                    PhoneNumber = U.PhoneNumber,
                    ProfilePic = U.profilePic,
                    Roles = userManager.GetRolesAsync(U).Result
                }).ToList();

                return View(users);
            }
            else
            {
                var user = await userManager.FindByEmailAsync(SearchValue);
                {
                    if (user is not null)
                    {
                        var mappedUser = new UserViewModel()
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            ProfilePic = user.profilePic,
                            Roles = userManager.GetRolesAsync(user).Result
                        };
                        return View(new List<UserViewModel>() { mappedUser });
                    }
                    else
                        return View(new List<UserViewModel>() { });
                }


            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //this helps protect against Cross-Site Request Forgery (CSRF) attacks by ensuring that the request came from the same application
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel) 
        {
            if (ModelState.IsValid)
            {
                var mappedUser = new ApplicationUser()
                {
                    Id = userViewModel.Id,
                    Email = userViewModel.Email,
                    UserName = userViewModel.UserName,
                    profilePic = userViewModel.ProfilePic,
                    PhoneNumber = userViewModel.PhoneNumber,
                };
                var result = await userManager.CreateAsync(mappedUser, userViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userViewModel);
        }

        public async Task<IActionResult> Details(string? id , string viewName = "Details")
        {
            if (id is null)
                return BadRequest();
            // else store the dept details in employee variable
            var user = await userManager.FindByIdAsync(id);
            // check if the returned employee is null return not found
            if (user is null)
                return NotFound();
            // else return the view and bind the employee
            var mappedUser = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                ProfilePic = user.profilePic
            };
            return View(viewName, mappedUser);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string? id)
        {
            return await Details(id,"Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string Id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(Id);
                await userManager.DeleteAsync(user);                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Error" , "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            var allRoles = await roleManager.Roles.ToListAsync();
            var userViewModel = new UserRoleViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Roles = allRoles.Select(r => new RoleViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    IsSelected = userManager.IsInRoleAsync(user , r.Name).Result
                }).ToList(),
            };
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(string Id , UserRoleViewModel updatedUser)
        {
            var user = await userManager.FindByIdAsync(updatedUser.Id);
            if (ModelState.IsValid)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                try
                {
                    foreach(var role in updatedUser.Roles) 
                    {
                        if(userRoles.Any(r=>r == role.Name) && !role.IsSelected)
                        {
                            await userManager.RemoveFromRoleAsync(user, role.Name);
                        }
                        if (!userRoles.Any(r => r == role.Name) && role.IsSelected)
                        {
                            await userManager.AddToRoleAsync(user, role.Name);
                        }
                    }
                    
                    user.UserName = updatedUser.UserName;
                    user.Email = updatedUser.Email;
                    user.PhoneNumber = updatedUser.PhoneNumber;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    
                    await userManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction("Error", "Home");
                }
            }
            return View(updatedUser);
            
        }
    }

    
}
