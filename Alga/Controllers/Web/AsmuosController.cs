﻿using Alga.Models;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


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
                vardai = vardai.Where(s => s.Vardas.Contains(searchString) || s.Pavarde.Contains(searchString));

            }

            if (User.IsInRole(RoleName.Admin))
                return View("IndexAdmin", vardai);

            return View("IndexGuest", vardai);
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
            if (User.IsInRole(RoleName.Admin))
                return View(asmuo);

            return View("DetailsReadOnly", asmuo);
        }

        // GET: Asmuos/Create
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asmuos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create([Bind(Include = "Id,Vardas,Pavarde,AlgaNet,VaikuSkaicius,AuginaVaikusVienas,AlgaGross", Exclude = "AsmuoImage")] Asmuo asmuo, HttpPostedFileBase asmuoImage)
        {

            if (ModelState.IsValid)
            {


                if (asmuoImage != null && asmuoImage.ContentLength > 0 && asmuoImage.ContentLength < 512000)
                {
                    //string pic = System.IO.Path.GetFileName(asmuoImage.FileName);
                    //string path = System.IO.Path.GetDirectoryName(asmuoImage.FileName);
                    //var type = System.IO.Path.GetFullPath(asmuoImage.FileName);
                    //var extension = asmuoImage.ContentType;
                    //var imageName = asmuoImage.FileName;
                    var fileExt = Path.GetExtension(asmuoImage.FileName);
                    if (fileExt.ToLower().EndsWith(".jpg"))
                    {

                    }

                    BinaryReader reader = new BinaryReader(asmuoImage.InputStream);
                    asmuo.AsmuoImage = reader.ReadBytes(asmuoImage.ContentLength);
                }
                else
                {

                    return View(asmuo);
                }



                db.Asmuos.Add(asmuo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asmuo);
        }

        // GET: Asmuos/Edit/5
        [Authorize(Roles = RoleName.Admin)]
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
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit([Bind(Include = "Id,Vardas,Pavarde,AlgaNet,VaikuSkaicius,AuginaVaikusVienas,AlgaGross,AsmuoImage")] Asmuo asmuo, HttpPostedFileBase asmuoImage)
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
        [Authorize(Roles = RoleName.Admin)]
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
        [Authorize(Roles = RoleName.Admin)]
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

        public FileContentResult GetImage(int id)
        {
            Asmuo asmuo = db.Asmuos.Find(id);
            if (asmuo != null)
            {

                byte[] imgBytes = asmuo.AsmuoImage;
                return File(asmuo.AsmuoImage, ".jpg");
            }
            else
            {
                return null;
            }
        }


        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Asmuo asmuo = db.Asmuos.Find(id);
        //    if (asmuo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if (User.IsInRole(RoleName.Admin))
        //        return View(asmuo);

        //    return View("DetailsReadOnly", asmuo);
        //}






    }
}
