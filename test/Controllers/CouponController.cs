using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Controllers
{
    public class CouponController : Controller
    {
        MovieBookingContext db = new MovieBookingContext();

        // GET: CouponCodesController
        public IActionResult Dashboard()
        {
            return View(db.Promocode.ToList());
        }

        public ActionResult Index()
        {
            return View(db.Promocode.ToList());
        }

        // GET: CouponCodesController/Details/5
        public ActionResult GetPromocode(string sercahkey)
        {

            var matchingProducts = db.Promocode.Where(p => p.Title.Contains(sercahkey) || p.Description.Contains(sercahkey) ||p.Website.Contains(sercahkey)).ToList<Promocode>();
            return View(matchingProducts);
        }

        public ActionResult User(Users user)
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


        // GET: CouponCodesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouponCodesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouponCodesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CouponCodesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouponCodesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CouponCodesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
