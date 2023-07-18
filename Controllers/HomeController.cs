using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Register", new Register(){BirthDate = DateTime.Now});
        }

        [HttpPost]
        public IActionResult Register (Register model)
        {
            // if (string.IsNullOrEmpty(model.UserName))
            // {
            //     ModelState.AddModelError(nameof(model.UserName), "UserName zorunlu");
            // }

            // if (string.IsNullOrEmpty(model.Email))
            //     ModelState.AddModelError(nameof(model.Email), "Email zorunlu");
            // else 
            // {
            //     if (!model.Email.Contains("@"))
            //     {
            //         ModelState.AddModelError(nameof(model.Email), "Email formatı hatalı");
            //     }
            // }

            // if (string.IsNullOrEmpty(model.Password))
            //     ModelState.AddModelError(nameof(model.Password), "Password zorunlu");
            // else
            // {
            //     if (model.Password.Length < 6)
            //     {
            //         ModelState.AddModelError(nameof(model.Password), "Password uzunluğu en az 6 karakter olmalıdır");
            //     }
            // }

            // if (!model.TermsAccepted)
            // {  
            //     ModelState.AddModelError(nameof(model.TermsAccepted), "Kullanıcı sözleşmesini kabul etmelisiniz");
            // }

            if (ModelState.IsValid)
                return View("Completed",model);
            else 
                return View(model);
        }
    }
}