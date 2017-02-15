﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alga.Models;

namespace Alga.Controllers
{
    public class AsmuosController : Controller
    {
        private AlgaContext db = new AlgaContext();

        // GET: Asmuos
        public ActionResult Index(string searchString)
        {
            var vardai = from v in db.Asmuos
                         select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vardai = vardai.Where(s => s.Vardas.Contains(searchString)||s.Pavarde.Contains(searchString));
            }

            return View(vardai);
        }


        // GET: Asmuos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asmuo asmuo = db.Asmuos.Find(id);
            if (asmuo == null)
            {
                return HttpNotFound();
            }
            return View(asmuo);
        }

        // GET: Asmuos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asmuos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vardas,Pavarde,AlgaNet")] Asmuo asmuo)
        {
            if (ModelState.IsValid)
            {
                db.Asmuos.Add(asmuo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asmuo);
        }

        // GET: Asmuos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asmuo asmuo = db.Asmuos.Find(id);
            if (asmuo == null)
            {
                return HttpNotFound();
            }
            return View(asmuo);
        }

        // POST: Asmuos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vardas,Pavarde,AlgaNet")] Asmuo asmuo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asmuo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asmuo);
        }

        // GET: Asmuos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asmuo asmuo = db.Asmuos.Find(id);
            if (asmuo == null)
            {
                return HttpNotFound();
            }
            return View(asmuo);
        }

        // POST: Asmuos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asmuo asmuo = db.Asmuos.Find(id);
            db.Asmuos.Remove(asmuo);
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
