using ElonsolMovies.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserApp.PL.Helpers;
using UserApp.PL.Models;

namespace UserApp.PL.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "UserHome");
            }
            return View();
        }

        [HttpPost]
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
                        // isPersistent indicate whether the sign in cookie should persist after the browser is closed or not
                        // 
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "UserHome");
                    }
                    ModelState.AddModelError(string.Empty, "Password is not correct");

                }
                ModelState.AddModelError(string.Empty, "Email doesn't exist");
            }
            return View(model);
        }

        public new async Task<IActionResult> Logout()
        {
            // delete token from cookie
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                registerViewModel.ProfilePic = DocumentSettings.UploadFile(registerViewModel.Pic, "Images\\UserImages");
                var mappedUser = new ApplicationUser()
                {
                    Id = registerViewModel.Id,
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName,
                    profilePic = registerViewModel.ProfilePic,
                    PhoneNumber = registerViewModel.PhoneNumber,
                };
                var result = await userManager.CreateAsync(mappedUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login","Account");
                }
                DocumentSettings.DeleteFile(mappedUser.profilePic, "Images\\UserImages");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerViewModel);

        }
    }
}
