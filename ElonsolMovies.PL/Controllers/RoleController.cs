using ElonsolMovies.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ElonsolMovies.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole>roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles =await roleManager.Roles.ToListAsync();
            return View(roles);
        }

        public async Task<IActionResult> Create (AddRoleViewModel addRoleViewModel)
        {
            if(ModelState.IsValid)
            {
                var roleExist = await roleManager.RoleExistsAsync(addRoleViewModel.Name);
                if(!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(addRoleViewModel.Name.Trim()));
                }
                else
                {
                    ModelState.AddModelError("Name", "Role is already exist");
                    return View("Index", await roleManager.Roles.ToListAsync());
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete (string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var mappedRole = new RoleViewModel()
            {
                Name = role.Name,
            };
            return View(mappedRole);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id ,  RoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var roleExist = await roleManager.RoleExistsAsync (model.Name);
                if(!roleExist)
                {
                    var role = await roleManager.FindByIdAsync(model.Id);
                    role.Name = model.Name;
                    await roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof (Index));
                }
                else
                {
                    ModelState.AddModelError("Name", "Role is already exist");
                    return View("Index", await roleManager.Roles.ToListAsync());
                }
            }
            return RedirectToAction(nameof(Index));
        }


    }
}