﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using domain.office;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace presentation.dashboard.pages.account {
    public class GetModel: BasePageModel {
        #region Constructor
        private readonly IAdmin_Container _adminContainer;
        public GetModel(IAdmin_Container adminContainer) {
            _adminContainer = adminContainer;
        }
        #endregion

        //#region Private
        //private IActionResult RedirectToLocal(string returnUrl) {
        //    if(Url.IsLocalUrl(returnUrl)) {
        //        return Redirect(returnUrl);
        //    }
        //    else {
        //        return RedirectToAction("Get", "Home");
        //    }
        //}
        //#endregion

        //[HttpGet, AllowAnonymous]
        //public async Task<IActionResult> SignIn(string returnUrl = null) {
        //    await Task.Factory.StartNew(() => {
        //        ViewData["ReturnUrl"] = returnUrl;
        //    });
        //    return View();
        //}

        //[HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        //public async Task<IActionResult> SignIn(Signin_DashboardModel collection, string returnUrl = null) {
        //    ViewData["ReturnUrl"] = returnUrl;
        //    if(ModelState.IsValid) {
        //        var admin = await _adminContainer.SignInAsync(collection.Username, collection.Password);
        //        if(admin != null) {
        //            if(admin.Status != 1) {
        //                Log.Information($"The lockout '{admin.FullName} (Id: {admin.Id})' tried to sign in.");
        //                return View("Lockout");
        //            }
        //            //TODO: RequiresTwoFactor
        //            Log.Information($"'{admin.FullName} (Id: {admin.Id})' signed in.");
        //            var accountPrincipal = _mapper.Map<AccountPrincipal>(admin);
        //            accountPrincipal.IP = IP;
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, accountPrincipal, new AuthenticationProperties {
        //                IsPersistent = collection.RememberMe
        //            });
        //            return RedirectToLocal(returnUrl);
        //        }
        //        else {
        //            ModelState.AddModelError(string.Empty, _stringLocalizer[SharedResource.InvalidSigninAttempt]);
        //            return View(collection);
        //        }
        //    }
        //    // There is obviously something wrong
        //    return View(collection);
        //}

        //[HttpPost]
        //public async Task<IActionResult> SignOut() {
        //    Log.Information($"Admin {User.Identity.Name} logged out at {DateTime.UtcNow}.");

        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    return RedirectToPage("/Account/SignedOut");
        //}
        public void OnGet() {

        }

        public async Task<IActionResult> OnPostSigninAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }
            var result = await _adminContainer.SignInAsync(Username, Password);
            if(result == null) {
                ModelState.AddModelError(string.Empty, _stringLocalizer["SigninFailed"]);
                return Page();
            }
            return RedirectToPage("home", "get");
        }

        [BindProperty, Required]
        public string Username { get; set; }
        [BindProperty, Required]
        public string Password { get; set; }
        [BindProperty]
        public bool RememberMe { get; set; }
    }
}