using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportSample.Models;

namespace AirportSample.Controllers
{
    public class cityinfoesController : Controller
    {
        private AirportDBEntities3 db = new AirportDBEntities3();

        // GET: cityinfoes
        public ActionResult Index()
        {
            return View(db.cityinfoes.ToList());
        }

        // GET: cityinfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cityinfo cityinfo = db.cityinfoes.Find(id);
            if (cityinfo == null)
            {
                return HttpNotFound();
            }
            return View(cityinfo);
        }

        // GET: cityinfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cityinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CITY,LAT,LONG")] cityinfo cityinfo)
        {
            if (ModelState.IsValid)
            {
                db.cityinfoes.Add(cityinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityinfo);
        }

        // GET: cityinfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cityinfo cityinfo = db.cityinfoes.Find(id);
            if (cityinfo == null)
            {
                return HttpNotFound();
            }
            return View(cityinfo);
        }

        // POST: cityinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CITY,LAT,LONG")] cityinfo cityinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityinfo);
        }

        // GET: cityinfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cityinfo cityinfo = db.cityinfoes.Find(id);
            if (cityinfo == null)
            {
                return HttpNotFound();
            }
            return View(cityinfo);
        }

        // POST: cityinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cityinfo cityinfo = db.cityinfoes.Find(id);
            db.cityinfoes.Remove(cityinfo);
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
