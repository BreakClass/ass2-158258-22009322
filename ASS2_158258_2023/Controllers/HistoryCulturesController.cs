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
    public class HistoryCulturesController : Controller
    {
        private ASS2_158258_2023Context db = new ASS2_158258_2023Context();

        // GET: HistoryCultures
        public ActionResult Index()
        {
            var historyCultures = db.HistoryCultures.Include(h => h.CityInfo);
            return View(historyCultures.ToList());
        }

        // GET: HistoryCultures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryCulture historyCulture = db.HistoryCultures.Find(id);
            if (historyCulture == null)
            {
                return HttpNotFound();
            }
            return View(historyCulture);
        }

        // GET: HistoryCultures/Create
        public ActionResult Create()
        {
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName");
            return View();
        }

        // POST: HistoryCultures/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,CityInfoId")] HistoryCulture historyCulture)
        {
            if (ModelState.IsValid)
            {
                db.HistoryCultures.Add(historyCulture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", historyCulture.CityInfoId);
            return View(historyCulture);
        }

        // GET: HistoryCultures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryCulture historyCulture = db.HistoryCultures.Find(id);
            if (historyCulture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", historyCulture.CityInfoId);
            return View(historyCulture);
        }

        // POST: HistoryCultures/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,CityInfoId")] HistoryCulture historyCulture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyCulture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityInfoId = new SelectList(db.CityInfoes, "Id", "CityName", historyCulture.CityInfoId);
            return View(historyCulture);
        }

        // GET: HistoryCultures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryCulture historyCulture = db.HistoryCultures.Find(id);
            if (historyCulture == null)
            {
                return HttpNotFound();
            }
            return View(historyCulture);
        }

        // POST: HistoryCultures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoryCulture historyCulture = db.HistoryCultures.Find(id);
            db.HistoryCultures.Remove(historyCulture);
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
