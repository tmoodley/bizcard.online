using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bizcard.online.Models;
using seoWebApplication.Framework;
using bizcard.online.Framework;

namespace bizcard.online.Controllers
{
    public class AssignedCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignedCards
        public ActionResult Index()
        {
            return View(db.AssignedCards.ToList());
        }

        // GET: AssignedCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedCards assignedCards = db.AssignedCards.Find(id);
            if (assignedCards == null)
            {
                return HttpNotFound();
            }
            return View(assignedCards);
        }

        // GET: AssignedCards/Create
        public ActionResult Create(int Id)
        {
            ViewBag.Id = Id; 
            ViewBag.UserId = User.Identity.Name;
            return PartialView();
        }

        // POST: AssignedCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        public ActionResult Create([Bind(Include = "Id,ToEmail,FromEmail,Message,CardId")] AssignedCards assignedCards)
        {
            if (ModelState.IsValid)
            {
                db.AssignedCards.Add(assignedCards);
                db.SaveChanges();

                var card = db.Cards.Find(assignedCards.CardId);
                if (card != null)
                {
                    //Get and populate template
                    var template = TemplateService.SendCard(card.ImageName, assignedCards.Message);
                    //send email
                    emailSend.SendGrid(assignedCards.ToEmail, "RE: " + card.Name, template); 
                }
               
                return Json(new { redirect = "/Cards/View/" });
            }
            return null;
            //return View(assignedCards);
        }

        // GET: AssignedCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedCards assignedCards = db.AssignedCards.Find(id);
            if (assignedCards == null)
            {
                return HttpNotFound();
            }
            return View(assignedCards);
        }

        // POST: AssignedCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ToEmail,FromEmail,Message,CardId")] AssignedCards assignedCards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedCards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignedCards);
        }

        // GET: AssignedCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedCards assignedCards = db.AssignedCards.Find(id);
            if (assignedCards == null)
            {
                return HttpNotFound();
            }
            return View(assignedCards);
        }

        // POST: AssignedCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedCards assignedCards = db.AssignedCards.Find(id);
            db.AssignedCards.Remove(assignedCards);
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
