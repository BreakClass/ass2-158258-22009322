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
    public class TouristAttractionsController : Controller
    {
        private ASS2_158258_2023Context db = new ASS2_158258_2023Context();

        // GET: TouristAttractions
        public ActionResult Index()
        {
            var touristAttractions = db.TouristAttractions.Include(t => t.CityInfo);
            return View(touristAttractions.ToList());
        }

        // GET: TouristAttractions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristAttraction touristAttraction = db.TouristAttractions.Find(id);
            if (touristAttraction == null)
            {
                return HttpNotFound();
            }
            return View(touristAttraction);
        }

        // GET: TouristAttractions/Create
        public ActionResult Create()
        {
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName");
            return View();
        }

        // POST: TouristAttractions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CityInfoId")] TouristAttraction touristAttraction)
        {
            if (ModelState.IsValid)
            {
                db.TouristAttractions.Add(touristAttraction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", touristAttraction.CityInfoId);
            return View(touristAttraction);
        }

        // GET: TouristAttractions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristAttraction touristAttraction = db.TouristAttractions.Find(id);
            if (touristAttraction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", touristAttraction.CityInfoId);
            return View(touristAttraction);
        }

        // POST: TouristAttractions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CityInfoId")] TouristAttraction touristAttraction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristAttraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", touristAttraction.CityInfoId);
            return View(touristAttraction);
        }

        // GET: TouristAttractions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristAttraction touristAttraction = db.TouristAttractions.Find(id);
            if (touristAttraction == null)
            {
                return HttpNotFound();
            }
            return View(touristAttraction);
        }

        // POST: TouristAttractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristAttraction touristAttraction = db.TouristAttractions.Find(id);
            db.TouristAttractions.Remove(touristAttraction);
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
