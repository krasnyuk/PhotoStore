using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotosStore.WebUI.Infrastructure.Abstract;
using PhotosStore.WebUI.Models;

namespace PhotosStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login()
        {
            return View();
        }
<<<<<<< HEAD
        //для проверки достоверности при авторизации 
=======

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
<<<<<<< HEAD
                    //если авториз. прошла редирект в админку
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin")); 
=======
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}