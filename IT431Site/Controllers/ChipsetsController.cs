using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT431Site.Models;

namespace IT431Site.Controllers
{
    public class ChipsetsController : Controller
    {
        private GraphicsCardsDataEntities db = new GraphicsCardsDataEntities();

        // GET: Chipsets
        public ActionResult Index()
        {
            return View(db.Chipsets.ToList());
        }

        // GET: Chipsets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chipset chipset = db.Chipsets.Find(id);
            if (chipset == null)
            {
                return HttpNotFound();
            }
            return View(chipset);
        }

        // GET: Chipsets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chipsets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChipsetID,ChipsetName")] Chipset chipset)
        {
            if (ModelState.IsValid)
            {
                db.Chipsets.Add(chipset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chipset);
        }

        // GET: Chipsets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chipset chipset = db.Chipsets.Find(id);
            if (chipset == null)
            {
                return HttpNotFound();
            }
            return View(chipset);
        }

        // POST: Chipsets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChipsetID,ChipsetName")] Chipset chipset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chipset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chipset);
        }

        // GET: Chipsets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chipset chipset = db.Chipsets.Find(id);
            if (chipset == null)
            {
                return HttpNotFound();
            }
            return View(chipset);
        }

        // POST: Chipsets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chipset chipset = db.Chipsets.Find(id);
            db.Chipsets.Remove(chipset);
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
