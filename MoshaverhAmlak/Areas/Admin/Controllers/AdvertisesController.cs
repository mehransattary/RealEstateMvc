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
    [Authorize(Roles ="Admin")]
    public class AdvertisesController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var advertise = db.AdvertiseRepository.GetAll();
            db.Dispose();
            return View(advertise);
        }

        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Advertise advertice = db.AdvertiseRepository.GetById(id.Value);
            db.Dispose();
            if (advertice == null)
            {
                return HttpNotFound();
            }
            return View(advertice);
        }

        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Advertise advertise, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "advertise" + advertise.Name;


                    WebImage img = new WebImage(file.InputStream);

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 400)
                        img.Resize(380, 380);
                    img.Save("~/Content/images/advertise/" + imgsrc2);
                    advertise.ImgPath = imgsrc2;


                }
                db = new UnitOfWork();
                db.AdvertiseRepository.Insert(advertise);
                db.AdvertiseRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return PartialView(advertise);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Advertise advertise = db.AdvertiseRepository.GetById(id);
            db.Dispose();
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return PartialView(advertise);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertise advertise, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/advertise/" + advertise.ImgPath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/advertise/" + advertise.ImgPath));
                    }
                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "Brand" + advertise.Name;


                    WebImage img = new WebImage(file.InputStream);

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 400)
                        img.Resize(380, 380);
                    img.Save("~/Content/images/advertise/" + imgsrc2);
                    advertise.ImgPath = imgsrc2;


                }
                db = new UnitOfWork();
                db.AdvertiseRepository.Update(advertise);
                db.AdvertiseRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(advertise);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            Advertise advertise = db.AdvertiseRepository.GetById(id);
            db.AdvertiseRepository.Delete(advertise);
            db.AdvertiseRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
