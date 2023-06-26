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
using MoshaverDataLayer.Context;
using System.Web.Helpers;

namespace MoshaverhAmlak.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GalleriesController : Controller
    {

        private UnitOfWork db;


        public ActionResult Index(int? id)

        {
            if(id!=null)
            {
                TempData["melkId"] = id;
              db = new UnitOfWork();
            var gallery = db.GalleryRepository.GetAll(x=>x.MelkId==id);
             ViewBag.melktitle= db.MelkRepository.GetById(id).Title;
             db.Dispose();
             
                return View(gallery);
            }
            return RedirectToAction("index", "Melks");
     
        }



        public ActionResult Create()
        {
          
             db = new UnitOfWork();
          
            if (TempData["melkId"] != null)
            {
                int id = Convert.ToInt32(TempData["melkId"]);
                var melk = db.MelkRepository.GetAll(x=>x.Id== id);
                ViewBag.MelkId = new SelectList(melk, "Id", "Title");
                db.Dispose();
                return PartialView();
            }
            else
            {
                var melk = db.MelkRepository.GetAll();
                ViewBag.MelkId = new SelectList(melk, "Id", "Title");
                db.Dispose();
                return PartialView();
            }            
    

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gallery gallery, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                   
                    Random random = new Random();
                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "gallery";


                    string imgsrc1 = "large" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/images/gallery/Big/") + imgsrc1);
                    gallery.ImgGalleryB = imgsrc1;


                    WebImage img = new WebImage(file.InputStream);
                    string imgsrc3 = "Standard" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 900)
                        img.Resize(600, 600);
                    img.Save("~/Content/images/gallery/Standard/" + imgsrc3);
                    gallery.ImgGalleryS = imgsrc3;

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 590)
                        img.Resize(400, 400);
                    img.Save("~/Content/images/gallery/Little/" + imgsrc2);
                    gallery.ImgGalleryL = imgsrc2;


                }
                db = new UnitOfWork();               
                db.GalleryRepository.Insert(gallery);
                db.GalleryRepository.Save();
                db.Dispose();
                return RedirectToAction("Index",new {id=gallery.MelkId });
            }

            return View(gallery);
        }


        public ActionResult Edit(int? id)
        {
            db = new UnitOfWork();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (TempData["melkId"] != null)
            {
              
                int id1 = Convert.ToInt32(TempData["melkId"]);
                var melk = db.MelkRepository.GetAll(x => x.Id == id1);
                ViewBag.MelkId = new SelectList(melk, "Id", "Title");
                Gallery gallery = db.GalleryRepository.GetById(id.Value);
                db.Dispose();
                return PartialView(gallery);
            }
            else
            {
               
                var melk = db.MelkRepository.GetAll();
                ViewBag.MelkId = new SelectList(melk, "Id", "Title");
                Gallery gallery = db.GalleryRepository.GetById(id.Value);
                db.Dispose();
                return PartialView(gallery);
            }

     
           

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gallery gallery, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    Random random = new Random();
                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "gallery";


                    string imgsrc1 = "large" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/images/gallery/Big/") + imgsrc1);
                    gallery.ImgGalleryB = imgsrc1;


                    WebImage img = new WebImage(file.InputStream);
                    string imgsrc3 = "Standard" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 900)
                        img.Resize(600, 600);
                    img.Save("~/Content/images/gallery/Standard/" + imgsrc3);
                    gallery.ImgGalleryS = imgsrc3;

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 590)
                        img.Resize(400, 400);
                    img.Save("~/Content/images/gallery/Little/" + imgsrc2);
                    gallery.ImgGalleryL = imgsrc2;


                }
                db = new UnitOfWork();
                db.GalleryRepository.Update(gallery);
                db.GalleryRepository.Save();
                db.Dispose();
                return RedirectToAction("Index",new { id = gallery.MelkId });
            }
            return View(gallery);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            Gallery gallery = db.GalleryRepository.GetById(id);
            db.GalleryRepository.Delete(gallery);
            db.GalleryRepository.Save();
            db.Dispose();

            return RedirectToAction("Index",new { id=gallery.MelkId});
        }
    }
}

