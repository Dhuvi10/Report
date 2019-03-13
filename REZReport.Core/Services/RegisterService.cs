using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using REZReport.Core.Entity;
using REZReport.Core.Helpers;
using REZReport.Core.Interfaces;
using REZReport.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace REZReport.Core.Services
{
    public class RegisterService: IRegister
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration config;
        public RegisterService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender, IConfiguration _config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_logger = logger;
            _emailSender = emailSender;
            config = _config;
        }

        public async Task<ResponseModel<string>> Register(RegisterModel Input)
        {
            ResponseModel<string> model = new ResponseModel<string>();
            try
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName };
                var result = await _userManager.CreateAsync(user, Input.Password);
                model.Status = result.Succeeded;
                if (result.Succeeded)
                {

                    model.Data = user.UserName;
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    if (code.Contains("+"))
                    {
                        code = code.Replace("+", " ");
                    }
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: HttpContext.);


                    var dataToConfirm = new ConfirmEmailModel
                    {
                        UserId = user.Id,
                        Code = code
                    };
                    var encryptedConfirmData = CryptoUtils.Encrypt(JsonConvert.SerializeObject(dataToConfirm));
                    var tt=config.GetSection("AppSetting").Value;
                    //var tt1= config["AppSetting:ConfirmationUrl"];
                   // var ss = config.GetSection("AppSetting");
                    var token = config.GetSection("AppSetting:ConfirmationUrl");
                    string callbackUrl = HtmlEncoder.Default.Encode(string.Format(token.Value.ToString(), user.Id,code));
                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                         $"Please confirm your account by <a href='"+callbackUrl+"'>clicking here</a>.");
                    // await _signInManager.SignInAsync(user, isPersistent: false);
                    //  return LocalRedirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                model.Error = ex.Message;
                model.Status = false;
                throw;
            }

            return model;
        }
        public async Task<ResponseModel<string>> EmailConfirm(string userId, string code)
        {
            ResponseModel<string> model = new ResponseModel<string>();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                model.Status = false;
                model.Error = $"Unable to load user with ID '{userId}'.";
            }
            if (code.Contains(" "))
            {
                code = code.Replace(" ", "+");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            model.Status = result.Succeeded;
            if (!result.Succeeded)
            {
                model.Error = $"Error confirming email for user with ID '{userId}':";
            }
            return model;
        }

    }
}
