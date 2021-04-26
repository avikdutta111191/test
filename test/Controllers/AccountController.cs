using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace test.Controllers
{
    [Route("Account")]

    public class AccountController : Controller
    {
        MovieBookingContext db = new MovieBookingContext();

        [Route("Login/{returnUrl?}")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = "Account/ValidateUser";
            Url.Action("ValidateUser", "Account");
            return View();
        }

        [Route("ValidateUser")]

        public ActionResult ValidateUser(Users user)
        {
            if (user == null)
            {
                return View();
            }
            else
            {

                var _user = db.Users.Where(s => s.Uname == user.Uname);
                if (_user.Any())
                {
                    if (_user.Where(s => s.Passwd == user.Passwd).Any())
                    {

                        return Json(new { status = true, message = "Login Successfull!" });
                    }
                    else
                    {
                        return Json(new { status = false, message = "Invalid Password!" });
                    }
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Email!" });
                }
            }
        }
    }

}
