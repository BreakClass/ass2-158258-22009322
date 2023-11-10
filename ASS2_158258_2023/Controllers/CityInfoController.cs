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
    public class CityInfoController : Controller
    {
        private ASS2_158258_2023Context db = new ASS2_158258_2023Context();

        // GET: CityInfo
        public ActionResult Index()
        {
            return View(db.CityInfoes.ToList());
        }

        // GET: CityInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityInfo cityInfo = db.CityInfoes.Find(id);
            if (cityInfo == null)
            {
                return HttpNotFound();
            }
            return View(cityInfo);
        }

        // GET: CityInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityInfo/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CityName,Description")] CityInfo cityInfo)
        {
            if (ModelState.IsValid)
            {
                db.CityInfoes.Add(cityInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityInfo);
        }

        // GET: CityInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityInfo cityInfo = db.CityInfoes.Find(id);
            if (cityInfo == null)
            {
                return HttpNotFound();
            }
            return View(cityInfo);
        }

        // POST: CityInfo/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CityName,Description")] CityInfo cityInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityInfo);
        }

        // GET: CityInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityInfo cityInfo = db.CityInfoes.Find(id);
            if (cityInfo == null)
            {
                return HttpNotFound();
            }
            return View(cityInfo);
        }

        // POST: CityInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityInfo cityInfo = db.CityInfoes.Find(id);
            db.CityInfoes.Remove(cityInfo);
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
