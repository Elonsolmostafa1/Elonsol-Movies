using ElonsolMovies.DAL.Models;
using ElonsolMovies.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElonsolMovies.PL.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public SignInManager<ApplicationUser> SignInManager { get; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var flag = await userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {
                         
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, false);
                        if (result.Succeeded && await userManager.IsInRoleAsync(user, "Admin"))
                            return RedirectToAction("Index", "User");
                        return RedirectToAction(nameof(AccessDenied));
                    }

                    ModelState.AddModelError(string.Empty, "Password isn't correct");
                }
                ModelState.AddModelError(string.Empty, "Email doesn't exist");
            }
            return View(model);
        }



        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Logout ()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
