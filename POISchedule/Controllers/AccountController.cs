namespace POISchedule.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using POISchedule.Data;
    using POISchedule.Data.Entities;
    using POISchedule.Helpers;
    using POISchedule.Models;
    using System.Linq;
    using System.Threading.Tasks;

    
    public class AccountController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public AccountController(DataContext dataContext,
            IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userHelper.LoginAsync(
                    model.UserName,
                    model.Password,
                    model.RememberMe);
                if (result.Succeeded)
                {
                    if(Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }
                    return RedirectToAction("Index","home");
                }
            }
            ModelState.AddModelError(string.Empty,"UserName or Password incorrect");
            model.Password = string.Empty;
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await userHelper.LogoutAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Register()
        {
            //TODO: ver el rol con un combo dara  de alta los roles en el seeder
            var model = new RegisterNewUserViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterNewUserViewModel model)
        {
            if(this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(model.UserName);
                if(user==null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        UserName = model.UserName,
                        Email = model.UserName
                    };
                    var result = await this.userHelper.AddUserAsync(user, model.Password);
                    if(result != IdentityResult.Success)
                    {
                        this.ModelState.AddModelError(string.Empty,"The user couldn't be created");
                        return View(model);
                    }
                    //TODO:Crear método para mostrar combo de roles
                    //TODO: cambiar viewmodel que maneje combo de roles
                    //TODO: cambiar vista para manejar combo de roles
                    //TODO: seleccion y asignacion del rol
                    
                    //await this.userHelper.AddUserToRoleAsync(user, "Admin");
                    //await this.userHelper.AddUserToRoleAsync(user, "User");
                    await this.userHelper.AddUserToRoleAsync(user, "Lender");
                    var result2 = await this.userHelper.LoginAsync(
                        model.UserName,
                        model.Password,
                        true);
                    if(result2.Succeeded)
                    {
                        return this.RedirectToAction("Index","Home");
                    }
                    this.ModelState.AddModelError(string.Empty, "The user couldn't be login");
                    return View(model);
                }
                this.ModelState.AddModelError(string.Empty, "The user is already registered");
                return View(model);
            }
            //TODO: checar combo de roles
            return View(model);
        }
    }
}
