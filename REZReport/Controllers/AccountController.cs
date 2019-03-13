using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REZReport.Core.Interfaces;
using REZReport.Core.Models;

namespace REZReport.Controllers
{
    public class AccountController : Controller
    {
        IRegister registerService;
        ILogin loginService;
        public AccountController(IRegister _registerService,ILogin _loginService)
        {
            registerService = _registerService;
            loginService = _loginService;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View( new LoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl=null)
        {
           // returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
               var result= await loginService.Login(model);
                if(result.Status)
                {
                    if (returnUrl != null)
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return LocalRedirect("/Home/index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
                return View();
           
        }
        [HttpGet]
        public IActionResult Create()
       {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                
            }
            else
            {
                var result =await registerService.Register(model);
                if(result.Status)
                {

                }
                else
                {

                }
            }
            return View();
        }
        [AllowAnonymous]
        
        public async Task<IActionResult> ConfirmEmail(string userId,string code)
        {
            ViewBag.result = await registerService.EmailConfirm(userId, code);
                return View();
        }
    }
}