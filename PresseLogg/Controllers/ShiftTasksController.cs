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
    public class ShiftTasksController : Controller
    {
        private LoggContext db = new LoggContext();

        // GET: ShiftTasks
        public ActionResult Index()
        {
            return View(db.ShiftTasks.ToList());
        }

        // GET: ShiftTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftTask shiftTask = db.ShiftTasks.Find(id);
            if (shiftTask == null)
            {
                return HttpNotFound();
            }
            return View(shiftTask);
        }

        // GET: ShiftTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,Task,Status")] ShiftTask shiftTask)
        {
            if (ModelState.IsValid)
            {
                db.ShiftTasks.Add(shiftTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiftTask);
        }

        // GET: ShiftTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftTask shiftTask = db.ShiftTasks.Find(id);
            if (shiftTask == null)
            {
                return HttpNotFound();
            }
            return View(shiftTask);
        }

        // POST: ShiftTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,Task,Status")] ShiftTask shiftTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiftTask);
        }

        // GET: ShiftTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftTask shiftTask = db.ShiftTasks.Find(id);
            if (shiftTask == null)
            {
                return HttpNotFound();
            }
            return View(shiftTask);
        }

        // POST: ShiftTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftTask shiftTask = db.ShiftTasks.Find(id);
            db.ShiftTasks.Remove(shiftTask);
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
