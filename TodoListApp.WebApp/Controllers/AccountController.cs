//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using TodoListApp.WebApp.Models;
//using TodoListApp.WebApp.Services;

//namespace TodoListApp.WebApp.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly IAccountService _accountService;

//        public AccountController(IAccountService accountService)
//        {
//            _accountService = accountService;
//        }

//        public IActionResult SignIn()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> SignIn(SignInViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await _accountService.SignInAsync(model);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Index", "Home");
//                }
//                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//            }
//            return View(model);
//        }

//        public IActionResult SignUp()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> SignUp(SignUpViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await _accountService.SignUpAsync(model);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("SignIn");
//                }
//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError(string.Empty, error.Description);
//                }
//            }
//            return View(model);
//        }
//    }
//}