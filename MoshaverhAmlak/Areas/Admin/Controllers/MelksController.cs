using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoshaverDataLayer.Model;
using MoshaverhAmlak.Models;
using System.Web.Helpers;
using PagedList;

namespace MoshaverhAmlak.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MelksController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index(int? page = 1)
        {
            var melks = db.Melks.Include(m => m.city).Include(m => m.typeCustumer).Include(m => m.typeGardad).Include(m => m.typeMahdode).Include(m => m.typeMelk).Include(m => m.typeSanad);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", melks.OrderBy(x => x.Id).ToPagedList((int)page, 18));
            }
            return View(melks.OrderBy(x => x.Id).ToPagedList((int)page, 18));


        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melk melk = db.Melks.Find(id);
            if (melk == null)
            {
                return HttpNotFound();
            }
            return View(melk);
        }


        public ActionResult Create()
        {

            ViewBag.cityId = new SelectList(db.Cityes, "Id", "cityname");
            ViewBag.typecustumerId = new SelectList(db.TypeCustumers, "Id", "Custumer");
            ViewBag.typeGardadId = new SelectList(db.TypeGardads, "Id", "typegardadname");
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodes, "Id", "typemahdodename");
            ViewBag.typeMelkId = new SelectList(db.TypeMelks, "Id", "typemelkname");
            ViewBag.typeSanadId = new SelectList(db.TypeSanads, "Id", "typesanadname");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Melk melk, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (file != null)
                    {

                        Random random = new Random();
                        string imgcode = random.Next(100000, 999000).ToString();
                        string imgname = "melk";


                        string imgsrc1 = "large" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                        file.SaveAs(HttpContext.Server.MapPath("~/Content/images/Melks/") + imgsrc1);
                        melk.ImgB = imgsrc1;


                        WebImage img = new WebImage(file.InputStream);
                        string imgsrc3 = "Standard" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                        if (img.Width > 900)
                            img.Resize(600, 600);
                        img.Save("~/Content/images/Melks/" + imgsrc3);
                        melk.ImgS = imgsrc3;

                        string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                        if (img.Width > 590)
                            img.Resize(400, 400);
                        img.Save("~/Content/images/Melks/" + imgsrc2);
                        melk.ImgL = imgsrc2;


                    }
                    melk.typeWriter = 1;
                    melk.userId = db.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().Email;
                    db.Melks.Add(melk);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Login", "Account");

            }


            ViewBag.cityId = new SelectList(db.Cityes, "Id", "cityname", melk.cityId);
            ViewBag.typecustumerId = new SelectList(db.TypeCustumers, "Id", "Custumer", melk.typecustumerId);
            ViewBag.typeGardadId = new SelectList(db.TypeGardads, "Id", "typegardadname", melk.typeGardadId);
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodes, "Id", "typemahdodename", melk.typeMahdodeId);
            ViewBag.typeMelkId = new SelectList(db.TypeMelks, "Id", "typemelkname", melk.typeMelkId);
            ViewBag.typeSanadId = new SelectList(db.TypeSanads, "Id", "typesanadname", melk.typeSanadId);
            return View(melk);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melk melk = db.Melks.Find(id);
            if (melk == null)
            {
                return HttpNotFound();
            }

            ViewBag.cityId = new SelectList(db.Cityes, "Id", "cityname", melk.cityId);
            ViewBag.typecustumerId = new SelectList(db.TypeCustumers, "Id", "Custumer", melk.typecustumerId);
            ViewBag.typeGardadId = new SelectList(db.TypeGardads, "Id", "typegardadname", melk.typeGardadId);
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodes, "Id", "typemahdodename", melk.typeMahdodeId);
            ViewBag.typeMelkId = new SelectList(db.TypeMelks, "Id", "typemelkname", melk.typeMelkId);
            ViewBag.typeSanadId = new SelectList(db.TypeSanads, "Id", "typesanadname", melk.typeSanadId);
            return View(melk);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Melk melk, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/Melks/" + melk.ImgB)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/Melks/" + melk.ImgB));
                    }
                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/Melks/" + melk.ImgS)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/Melks/" + melk.ImgS));
                    }
                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/Melks/" + melk.ImgL)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/Melks/" + melk.ImgL));
                    }

                    Random random = new Random();
                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "melk";


                    string imgsrc1 = "large" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/images/Melks/") + imgsrc1);
                    melk.ImgB = imgsrc1;


                    WebImage img = new WebImage(file.InputStream);
                    string imgsrc3 = "Standard" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 900)
                        img.Resize(600, 600);
                    img.Save("~/Content/images/Melks/" + imgsrc3);
                    melk.ImgS = imgsrc3;

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 590)
                        img.Resize(400, 400);
                    img.Save("~/Content/images/Melks/" + imgsrc2);
                    melk.ImgL = imgsrc2;


                }
                melk.typeWriter = 1;
                db.Entry(melk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cityId = new SelectList(db.Cityes, "Id", "cityname", melk.cityId);
            ViewBag.typecustumerId = new SelectList(db.TypeCustumers, "Id", "Custumer", melk.typecustumerId);
            ViewBag.typeGardadId = new SelectList(db.TypeGardads, "Id", "typegardadname", melk.typeGardadId);
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodes, "Id", "typemahdodename", melk.typeMahdodeId);
            ViewBag.typeMelkId = new SelectList(db.TypeMelks, "Id", "typemelkname", melk.typeMelkId);
            ViewBag.typeSanadId = new SelectList(db.TypeSanads, "Id", "typesanadname", melk.typeSanadId);
            return View(melk);
        }


        public ActionResult Delete(int? id)
        {
            Melk melk = db.Melks.Find(id);
            db.Melks.Remove(melk);
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
