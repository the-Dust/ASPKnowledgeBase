using ASPKnowledgeBase.Infrastructure.Base;
using ASPKnowledgeBase.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ASPKnowledgeBase.Controllers
{
    public class LoginController : Controller
    {
        IAuthProvider authProvider;

        public LoginController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetLoginState()
        {
            return PartialView("_LoginState");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult LoginLink(string partial = "_LoginLink")
        {
            bool auth = System.Web.HttpContext.Current.User?.Identity.IsAuthenticated ?? false;

            if (auth)
            {
                var userName = Thread.CurrentPrincipal.Identity.Name;
                return PartialView(partial, new LoginLinkUser { IsLoggedIn = true, Login = userName });
            }
            return PartialView(partial, new LoginLinkUser { IsLoggedIn = false });
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult LoginModal(LoginUser user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName) &&
                !string.IsNullOrWhiteSpace(user.Password) &&
                ModelState.IsValid)
            {
                if (authProvider.Authenticate(user.UserName, user.Password))
                {
                    return PartialView("_LoginClosePartial");
                }
                else
                {
                    ModelState.AddModelError("Enter", "Неправильный логин или пароль");
                    return PartialView("_LoginInsidePartial", user);
                }
            }
            else
            {
                return PartialView("_LoginInsidePartial", user);
            }
        }

        public ActionResult Logout()
        {
            authProvider.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}