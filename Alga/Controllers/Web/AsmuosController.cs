using Alga.Models;
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
        public ActionResult Create(
            [Bind(Include = "Id,Vardas,Pavarde,AlgaNet,VaikuSkaicius,AuginaVaikusVienas,AlgaGross", Exclude = "AsmuoImage")]
        Asmuo asmuo, HttpPostedFileBase asmuoImage)

        {
            if (!ModelState.IsValid) return View(asmuo);

            var fileExt = Path.GetExtension(asmuoImage.FileName);
            if (asmuoImage != null
                && asmuoImage.ContentLength > 0
                && asmuoImage.ContentLength < 512000
                && fileExt.ToLower().EndsWith(".jpg")
                && IsFileImage(asmuoImage))
            {
                BinaryReader reader = new BinaryReader(asmuoImage.InputStream);
                asmuo.AsmuoImage = reader.ReadBytes(asmuoImage.ContentLength);
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




        public bool IsFileImage(HttpPostedFileBase file) //Check's if uploaded file is an image
        {
            bool result;
            try
            {
                System.Drawing.Image imgInput = System.Drawing.Image.FromStream(file.InputStream);
                System.Drawing.Graphics gInput = System.Drawing.Graphics.FromImage(imgInput);
                System.Drawing.Imaging.ImageFormat thisFormat = imgInput.RawFormat;
                file.InputStream.Position = 0; //reset InputStream  reader position to 0
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
