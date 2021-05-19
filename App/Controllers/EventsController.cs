using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App.Models;
using Microsoft.AspNet.Identity;

namespace App.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            string currenUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == currenUserId);
            //return View(db.EventCategories.ToList().Where(X => X.User == currentUser));
            var events = db.Events.Include(p => p.EventCategory).Include(p => p.Organization);
            return View(events.ToList().Where(X => X.User == currentUser));
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.CategoryEventId = new SelectList(db.EventCategories, "CategoryEventId", "CategoryEventName");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationName");
            return View();
        }

        // POST: Events/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventName,Description,Start,End,ThemeColor,IsFullDay,CategoryEventId,OrganizationId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                string currenUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currenUserId);
                @event.User = currentUser;
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryEventId = new SelectList(db.EventCategories, "CategoryEventId", "CategoryEventName", @event.CategoryEventId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationName", @event.OrganizationId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryEventId = new SelectList(db.EventCategories, "CategoryEventId", "CategoryEventName", @event.CategoryEventId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationName", @event.OrganizationId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,Description,Start,End,ThemeColor,IsFullDay,CategoryEventId,OrganizationId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryEventId = new SelectList(db.EventCategories, "CategoryEventId", "CategoryEventName", @event.CategoryEventId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "OrganizationName", @event.OrganizationId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
