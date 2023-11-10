using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASS2_158258_2023.Data;
using ASS2_158258_2023.Models;

namespace ASS2_158258_2023.Controllers
{
    public class SpecialtyFoodsController : Controller
    {
        private ASS2_158258_2023Context db = new ASS2_158258_2023Context();

        // GET: SpecialtyFoods
        public ActionResult Index()
        {
            var specialtyFoods = db.SpecialtyFoods.Include(s => s.CityInfo);
            return View(specialtyFoods.ToList());
        }

        // GET: SpecialtyFoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialtyFood specialtyFood = db.SpecialtyFoods.Find(id);
            if (specialtyFood == null)
            {
                return HttpNotFound();
            }
            return View(specialtyFood);
        }

        // GET: SpecialtyFoods/Create
        public ActionResult Create()
        {
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName");
            return View();
        }

        // POST: SpecialtyFoods/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CityInfoId")] SpecialtyFood specialtyFood)
        {
            if (ModelState.IsValid)
            {
                db.SpecialtyFoods.Add(specialtyFood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", specialtyFood.CityInfoId);
            return View(specialtyFood);
        }

        // GET: SpecialtyFoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialtyFood specialtyFood = db.SpecialtyFoods.Find(id);
            if (specialtyFood == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", specialtyFood.CityInfoId);
            return View(specialtyFood);
        }

        // POST: SpecialtyFoods/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CityInfoId")] SpecialtyFood specialtyFood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialtyFood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", specialtyFood.CityInfoId);
            return View(specialtyFood);
        }

        // GET: SpecialtyFoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialtyFood specialtyFood = db.SpecialtyFoods.Find(id);
            if (specialtyFood == null)
            {
                return HttpNotFound();
            }
            return View(specialtyFood);
        }

        // POST: SpecialtyFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialtyFood specialtyFood = db.SpecialtyFoods.Find(id);
            db.SpecialtyFoods.Remove(specialtyFood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
