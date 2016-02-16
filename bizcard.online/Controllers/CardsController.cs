using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bizcard.online.Models;

namespace bizcard.online.Controllers
{
    public class CardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cards
        public ActionResult Index()
        {
            return View(db.Cards.ToList());
        } 

        // GET: Cards
        public ActionResult Send()
        {
            return View(db.Cards.ToList());
        }

        // GET: Cards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cards cards = db.Cards.Find(id);
            if (cards == null)
            {
                return HttpNotFound();
            }
            return View(cards);
        }

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ImageName")] Cards cards)
        {
            if (ModelState.IsValid)
            {
                db.Cards.Add(cards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cards);
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cards cards = db.Cards.Find(id);
            if (cards == null)
            {
                return HttpNotFound();
            }
            return View(cards);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ImageName")] Cards cards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cards);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cards cards = db.Cards.Find(id);
            if (cards == null)
            {
                return HttpNotFound();
            }
            return View(cards);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cards cards = db.Cards.Find(id);
            db.Cards.Remove(cards);
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
