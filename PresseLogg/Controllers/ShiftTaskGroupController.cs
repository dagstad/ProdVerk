using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PresseLogg.DAL;
using PresseLogg.Models;

namespace PresseLogg.Controllers
{
    public class ShiftTaskGroupController : Controller
    {
        private LoggContext db = new LoggContext();

        // GET: ShiftTaskGroup
        public ActionResult Index()
        {
            return View(db.ShiftTaskGroups.ToList());
        }

        // GET: ShiftTaskGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftTaskGroup shiftTaskGroup = db.ShiftTaskGroups.Find(id);
            if (shiftTaskGroup == null)
            {
                return HttpNotFound();
            }
            return View(shiftTaskGroup);
        }

        // GET: ShiftTaskGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftTaskGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftTaskGroupId,ShiftTaskGroupName,ShiftTaskId")] ShiftTaskGroup shiftTaskGroup)
        {
            if (ModelState.IsValid)
            {
                db.ShiftTaskGroups.Add(shiftTaskGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiftTaskGroup);
        }

        // GET: ShiftTaskGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftTaskGroup shiftTaskGroup = db.ShiftTaskGroups.Find(id);
            if (shiftTaskGroup == null)
            {
                return HttpNotFound();
            }
            return View(shiftTaskGroup);
        }

        // POST: ShiftTaskGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftTaskGroupId,ShiftTaskGroupName,ShiftTaskId")] ShiftTaskGroup shiftTaskGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftTaskGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiftTaskGroup);
        }

        // GET: ShiftTaskGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftTaskGroup shiftTaskGroup = db.ShiftTaskGroups.Find(id);
            if (shiftTaskGroup == null)
            {
                return HttpNotFound();
            }
            return View(shiftTaskGroup);
        }

        // POST: ShiftTaskGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftTaskGroup shiftTaskGroup = db.ShiftTaskGroups.Find(id);
            db.ShiftTaskGroups.Remove(shiftTaskGroup);
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
