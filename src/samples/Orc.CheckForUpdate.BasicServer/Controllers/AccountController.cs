// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="ORC">
//   MS-PL
// </copyright>
// <summary>
//   Defines the AccountController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orc.CheckForUpdate.BasicServer.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    using Orc.CheckForUpdate.BasicServer.Models;

    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Gets the authentication manager.
        /// </summary>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Account
        /// <summary>
        /// The login action.
        /// </summary>
        /// <param name="returnUrl">
        /// The return Url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel { UserName = "Admin", Password = "manager" });
        }

        /// <summary>
        /// Process user's login action.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.UserName) && model.UserName.ToLower() == "admin"
                    && model.Password == "manager")
                {
                    var claims = new List<Claim>
                                     {
                                         new Claim(ClaimTypes.Name, "Brock"),
                                         new Claim(ClaimTypes.Email, "brockallen@gmail.com")
                                     };
                    var id = new ClaimsIdentity(claims,
                                                DefaultAuthenticationTypes.ApplicationCookie);

                    this.AuthenticationManager.SignIn(id);
                    return RedirectToLocal(returnUrl);
                }

                this.ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        /// <summary>
        /// The redirect to local.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}