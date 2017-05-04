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
    public class GPUCardsController : Controller
    {
        private GraphicsCardsDataEntities db = new GraphicsCardsDataEntities();

        // GET: GPUCards
        public ActionResult Index()
        {
            var gPUCards = db.GPUCards.Include(g => g.Chipset).Include(g => g.Manufacturer);
            return View(gPUCards.ToList());
        }

        // GET: GPUCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPUCard gPUCard = db.GPUCards.Find(id);
            if (gPUCard == null)
            {
                return HttpNotFound();
            }
            return View(gPUCard);
        }

        [Authorize]
        // GET: GPUCards/Create
        public ActionResult Create()
        {
            ViewBag.ChipsetID = new SelectList(db.Chipsets, "ChipsetID", "ChipsetName");
            ViewBag.ManufactureID = new SelectList(db.Manufacturers, "ManufactureID", "ManufacturerName");
            return View();
        }

        // POST: GPUCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GPUCardID,ChipsetID,ManufactureID,Price,MemoryType,Memory,ClockSpeed,ImageLink,ReleaseDate")] GPUCard gPUCard)
        {
            if (ModelState.IsValid)
            {
                db.GPUCards.Add(gPUCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChipsetID = new SelectList(db.Chipsets, "ChipsetID", "ChipsetName", gPUCard.ChipsetID);
            ViewBag.ManufactureID = new SelectList(db.Manufacturers, "ManufactureID", "ManufacturerName", gPUCard.ManufactureID);
            return View(gPUCard);
        }

        [Authorize]
        // GET: GPUCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPUCard gPUCard = db.GPUCards.Find(id);
            if (gPUCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChipsetID = new SelectList(db.Chipsets, "ChipsetID", "ChipsetName", gPUCard.ChipsetID);
            ViewBag.ManufactureID = new SelectList(db.Manufacturers, "ManufactureID", "ManufacturerName", gPUCard.ManufactureID);
            return View(gPUCard);
        }

        // POST: GPUCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GPUCardID,ChipsetID,ManufactureID,Price,MemoryType,Memory,ClockSpeed,ImageLink,ReleaseDate")] GPUCard gPUCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gPUCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChipsetID = new SelectList(db.Chipsets, "ChipsetID", "ChipsetName", gPUCard.ChipsetID);
            ViewBag.ManufactureID = new SelectList(db.Manufacturers, "ManufactureID", "ManufacturerName", gPUCard.ManufactureID);
            return View(gPUCard);
        }

        [Authorize]
        // GET: GPUCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPUCard gPUCard = db.GPUCards.Find(id);
            if (gPUCard == null)
            {
                return HttpNotFound();
            }
            return View(gPUCard);
        }

        // POST: GPUCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPUCard gPUCard = db.GPUCards.Find(id);
            db.GPUCards.Remove(gPUCard);
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
