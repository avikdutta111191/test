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

        public ActionResult GetUserPayout(string username)
        {
            if (username  == null)
            {
                return View();
            }
            else
            {

                var _user = db.Users.Where(s => s.Uname == username).Select(s=>s.Userid).ToArray();
                if (_user.Any())
                {
                    var totalBalance = db.Promocode.Select(s => s.Amount*s.MaxCount).ToArray();

                    var values =db.UserPromocodes.Where(s => s.Userid == _user[0]).Select(s=>s.Value).ToArray();
                    if (values!=null|| totalBalance!=null)
                    {

                        return Json(new { status = true, Payout = values.Sum(), Balance = totalBalance.Sum()}); 
                    }
                    else
                    {
                        return Json(new { status = false, Payout = 0, Balance = 0 });
                    }
                }
                else
                {
                    return Json(new { status = false, Payout = 0, Balance = 0 });
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
