using System;
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
using Microsoft.AspNetCore.Mvc;
using presentation.dashboard.helpers;
using presentation.dashboard.models;
using Serilog;

namespace presentation.dashboard.controllers {
    public class AccountController: BaseController {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IAdminContainer _adminContainer;
        public AccountController(IMapper mapper, IAdminContainer adminContainer) {
            _mapper = mapper;
            _adminContainer = adminContainer;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> SignIn(SigninBindingModel collection, string returnUrl) {
            var admin = await _adminContainer.SignIn(collection.Username, collection.Password);
            if(admin != null) {
                var accountPrincipal = _mapper.Map<AccountPrincipal>(admin);
                accountPrincipal.IP = IP;
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, accountPrincipal, new AuthenticationProperties {
                    IsPersistent = collection.RememberMe
                });
                if(string.IsNullOrWhiteSpace(returnUrl))
                    return RedirectToAction("Get", "Home");
                else
                    Redirect(returnUrl);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignOut() {
            Log.Information($"Admin {User.Identity.Name} logged out at {DateTime.UtcNow}.");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Account/SignedOut");
        }
    }
}
