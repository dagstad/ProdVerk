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
using System.Data.Entity.SqlServer;

namespace PresseLogg.Controllers
{
    public class PressLogController : Controller
    {
        private LoggContext db = new LoggContext();

        // GET: Logg
        public ActionResult Index(string searchString, string option, string sortOrder, string press)
        {

            ViewBag.ArticleSortParm = String.IsNullOrEmpty(sortOrder) ? "articleId_desc" : "";
            ViewBag.PresseSortParm = sortOrder == "Presse" ? "presse_desc" : "Presse";



            var logger = from s in db.PressLogs
                         select s;

            switch (sortOrder)
            {
                case "articleId_desc":
                    logger = logger.OrderByDescending(s => s.ArticleId);
                    break;
                case "presse_desc":
                    logger = logger.OrderBy(s => s.Presse);
                    break;
                case "Presse":
                    logger = logger.OrderByDescending(s => s.Presse);
                    break;
                default:
                    logger = logger.OrderBy(s => s.ArticleId);
                    break;
            }

            var PressLst = new List<string>();

            var PressQry = from d in db.PressLogs
                           select d.Presse.ToString();
            PressLst.AddRange(PressQry.Distinct());
            ViewBag.press = new SelectList(PressLst);

            var presser = from m in db.PressLogs
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                logger = logger.Where(s => s.Article.Name.Contains(searchString) || SqlFunctions.StringConvert((decimal)s.Article.ArticleId).Contains(searchString) || s.Kommentar.Contains(searchString));
            }

            if (string.IsNullOrEmpty(press))
                return View(logger.ToList());
            else
            {
                return View(logger.ToList().Where(x => x.Presse.ToString() == press));
            }


            //var logger = db.Logger.Include(l => l.Article);
            //return View(logger.ToList());
        }

        // GET: Logg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressLog logg = db.PressLogs.Find(id);
            if (logg == null)
            {
                return HttpNotFound();
            }
            return View(logg);
        }

        // GET: Logg/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleId");
            return View();
        }

        // POST: Logg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArticleId,Presse,TonnPrTime,TempMixer1,TempMixer2,Damptrykk,KgDampPrTime,KonTrykk,Oppholdstid,TempExpander,AmpMixer1,AmpMixer2,AmpExpander,VinkelOAP,AmpPresse,TempKjøle,Kommentar")] PressLog logg)
        {
            if (ModelState.IsValid)
            {
                db.PressLogs.Add(logg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleId", logg.ArticleId);
            return View(logg);
        }

        // GET: Logg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressLog logg = db.PressLogs.Find(id);
            if (logg == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleId", logg.ArticleId);
            return View(logg);
        }

        // POST: Logg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArticleId,Presse,TonnPrTime,TempMixer1,TempMixer2,Damptrykk,KgDampPrTime,KonTrykk,Oppholdstid,TempExpander,AmpMixer1,AmpMixer2,AmpExpander,VinkelOAP,AmpPresse,TempKjøle,Kommentar")] PressLog logg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleId", logg.ArticleId);
            return View(logg);
        }

        // GET: Logg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressLog logg = db.PressLogs.Find(id);
            if (logg == null)
            {
                return HttpNotFound();
            }
            return View(logg);
        }

        // POST: Logg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PressLog logg = db.PressLogs.Find(id);
            db.PressLogs.Remove(logg);
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
