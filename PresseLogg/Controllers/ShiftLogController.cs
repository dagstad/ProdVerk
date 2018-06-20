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
    public class ShiftLogController : Controller
    {
        private LoggContext db = new LoggContext();

        // GET: ShiftLog
        public ActionResult Index()
        {
            var shiftLogs = db.ShiftLogs.Include(s => s.ShiftTaskGroup);
            return View(shiftLogs.ToList());
        }

        // GET: ShiftLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftLog shiftLog = db.ShiftLogs.Find(id);
            if (shiftLog == null)
            {
                return HttpNotFound();
            }
            return View(shiftLog);
        }

        // GET: ShiftLog/Create
        public ActionResult Create()
        {
            ViewBag.ShiftTaskGroupId = new SelectList(db.ShiftTaskGroups, "ShiftTaskGroupId", "ShiftTaskGroupName");
            return View();
        }

        // POST: ShiftLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftLogId,ShiftTaskGroupId,Shift,Date,Text,PictureId")] ShiftLog shiftLog)
        {
            if (ModelState.IsValid)
            {
                db.ShiftLogs.Add(shiftLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShiftTaskGroupId = new SelectList(db.ShiftTaskGroups, "ShiftTaskGroupId", "ShiftTaskGroupName", shiftLog.ShiftTaskGroupId);
            return View(shiftLog);
        }

        // GET: ShiftLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftLog shiftLog = db.ShiftLogs.Find(id);
            if (shiftLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShiftTaskGroupId = new SelectList(db.ShiftTaskGroups, "ShiftTaskGroupId", "ShiftTaskGroupName", shiftLog.ShiftTaskGroupId);
            return View(shiftLog);
        }

        // POST: ShiftLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftLogId,ShiftTaskGroupId,Shift,Date,Text,PictureId")] ShiftLog shiftLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShiftTaskGroupId = new SelectList(db.ShiftTaskGroups, "ShiftTaskGroupId", "ShiftTaskGroupName", shiftLog.ShiftTaskGroupId);
            return View(shiftLog);
        }

        // GET: ShiftLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftLog shiftLog = db.ShiftLogs.Find(id);
            if (shiftLog == null)
            {
                return HttpNotFound();
            }
            return View(shiftLog);
        }

        // POST: ShiftLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftLog shiftLog = db.ShiftLogs.Find(id);
            db.ShiftLogs.Remove(shiftLog);
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
