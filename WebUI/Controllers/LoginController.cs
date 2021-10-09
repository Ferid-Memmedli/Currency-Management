using Business.Abstract;
using Business.Concrete;
using Business.FluentValidation;
using Core.UtilitiesCore.Results.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IUserService userService;
        public LoginController()
        {
            userService  = new UserManager(new EfUserDal(),new UserValidator());
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn([Bind(Include = "UserID,Email,Password")] User user)
        {
            IDataResult<User> result = await userService.GetByUserAsync(user);
            if (result.Success)
            {
                ViewBag.Error = "";
                User userData = result.Data;
                FormsAuthentication.SetAuthCookie(userData.Email,true);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = result.Message;
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> SignUp([Bind(Include = "UserID,Email,Password")] User user)
        {
            IDataResult<List<ValidationFailure>> result = await userService.AddUserAsync(user);

            if (result.Success)
            {
                ModelState.Clear();
                return RedirectToAction("SignIn");
            }
            
            foreach (var item in result.Data)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(user);
        }
    }
}