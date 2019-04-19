﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using domain.office;
using MD.PersianDateTime.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentation.dashboard.helpers;
using presentation.dashboard.models;
using Serilog;

namespace presentation.dashboard.controllers {
    public class AccountController: BaseController {
        #region Constructor
        private readonly IAdminContainer _adminContainer;
        public AccountController(IAdminContainer adminContainer) {
            _adminContainer = adminContainer;
        }
        #endregion

        #region Private
        private IActionResult RedirectToLocal(string returnUrl) {
            if(Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            else {
                return RedirectToAction(nameof(HomeController.Get), "Home");
            }
        }
        #endregion
        [HttpGet, AllowAnonymous]
        public IActionResult SignIn(string returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SigninBindingModel collection, string returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            if(ModelState.IsValid) {
                var admin = await _adminContainer.SignIn(collection.Username, collection.Password);
                if(admin != null) {
                    if(admin.Status != 1) {
                    Log.Information($"The lockout '{admin.FullName} (Id: {admin.Id})' tried to signin.");
                        return View("Lockout");
                    }
                    //TODO: RequiresTwoFactor
                    Log.Information($"'{admin.FullName} (Id: {admin.Id})' signed in.");
                    var accountPrincipal = _mapper.Map<AccountPrincipal>(admin);
                    accountPrincipal.IP = IP;
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, accountPrincipal, new AuthenticationProperties {
                        IsPersistent = collection.RememberMe
                    });
                    return RedirectToLocal(returnUrl);
                }
                else {
                    ModelState.AddModelError(string.Empty, _stringLocalizer["Invalid signin attempt"]);
                    return View(collection);
                }
            }
            // There is obviously something wrong
            return View(collection);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut() {
            Log.Information($"Admin {User.Identity.Name} logged out at {DateTime.UtcNow}.");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Account/SignedOut");
        }
    }
}
