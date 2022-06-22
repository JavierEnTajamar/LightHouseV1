using LightHouseV1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightHouseV1.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel vm)
        {
            
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = vm.Email,
                    Email = vm.Email
                };
                
                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {                    
                    await _signInManager.SignInAsync(user, false);
                    Castaway castaway = new Castaway();                    
                    
                    castaway.User = user;
                    castaway.CastawayId = await _db.Castaways.CountAsync() + 100;
                    await _db.Castaways.AddAsync(castaway);
                    await _userManager.AddToRoleAsync(castaway.User, "Castaway");
                    await _db.SaveChangesAsync();
                    await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, false, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(vm);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Login Failure");
            }
            return View(vm);
        }
    }
}
