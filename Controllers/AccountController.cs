using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcproj.Models;
using mvcproj.View_Models;

namespace mvcproj.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly Reservecotexet _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager , RoleManager<IdentityRole> _roleManager , Reservecotexet context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            roleManager = _roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Address= model.Address
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            if (!await roleManager.RoleExistsAsync("Guest"))
            {
                await roleManager.CreateAsync(new IdentityRole("Guest"));
            }

            await userManager.AddToRoleAsync(user, "Guest");

            var guest = new Guest
            {
                UserId = user.Id, 
                Name = model.UserName,
                Phone = model.Phone,
                Email = model.Email,
                Address =model.Address
                
            };

            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            await signInManager.SignInAsync(user, isPersistent: false);

            return Ok("Guest registered successfully!");
        }

    }
}
