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
    public class BrandsController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var brand = db.BrandRepository.GetAll();
            db.Dispose();
            return View(brand);
        }



        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                   
                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "Brand"+ brand.Name;


                    WebImage img = new WebImage(file.InputStream);

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 210)
                        img.Resize(200, 200);
                    img.Save("~/Content/images/Brand/" + imgsrc2);
                    brand.ImgPath = imgsrc2;


                }
                db = new UnitOfWork();
                db.BrandRepository.Insert(brand);
                db.BrandRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return PartialView(brand);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Brand brand = db.BrandRepository.GetById(id);
            db.Dispose();
            if (brand == null)
            {
                return HttpNotFound();
            }
            return PartialView(brand);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/Brand/" + brand.ImgPath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/Brand/" + brand.ImgPath));
                    }
                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "Brand" + brand.Name;


                    WebImage img = new WebImage(file.InputStream);

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 210)
                        img.Resize(200, 200);
                    img.Save("~/Content/images/Brand/" + imgsrc2);
                    brand.ImgPath = imgsrc2;


                }
                db = new UnitOfWork();
                db.BrandRepository.Update(brand);
                db.BrandRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            Brand brand = db.BrandRepository.GetById(id);
            db.BrandRepository.Delete(brand);
            db.BrandRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
