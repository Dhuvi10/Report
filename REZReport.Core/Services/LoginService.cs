using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using REZReport.Core.Entity;
using REZReport.Core.Interfaces;
using REZReport.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REZReport.Core.Services
{
   public class LoginService:ILogin
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly ILogger<LoginModel> _logger;

        public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
           // _logger = logger;
        }

        public async Task<ResponseModel<string>> Login(LoginModel model)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
               await _signInManager.SignInAsync(user, isPersistent: false);


              



                response.Status = true;
                response.Message = "User logged in";
            }
            else
            {
                response.Error = "Invalid login attempt.";
                response.Status = false;
            }
            //if (result.RequiresTwoFactor)
            //{
            //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
            //}
            if (result.IsLockedOut)
            {
                response.Error = "User Locked";
                response.Status = false;
            }
            return response;
        }

    }
}
