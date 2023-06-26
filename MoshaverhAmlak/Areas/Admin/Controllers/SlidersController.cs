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
    public class SlidersController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var slider = db.SliderRepository.GetAll();
            db.Dispose();
            return View(slider);
        }



        public ActionResult Create()
        {
            db = new UnitOfWork();
            ViewBag.MelkId = new SelectList(db.MelkRepository.GetAll(),"Id", "Title");
            db.Dispose();
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "slider";


                    WebImage img = new WebImage(file.InputStream);
                 
                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 1200)
                        img.Resize(1000, 1000);
                    img.Save("~/Content/images//Little/" + imgsrc2);
                    slider.SliderIMG = imgsrc2;


                }
                db = new UnitOfWork();
                db.SliderRepository.Insert(slider);
                db.SliderRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return PartialView(slider);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Slider slider = db.SliderRepository.GetById(id);
            ViewBag.MelkId = new SelectList(db.MelkRepository.GetAll(), "Id", "Title");
            db.Dispose();
            if (slider == null)
            {
                return HttpNotFound();
            }
            return PartialView(slider);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/Little/" + slider.SliderIMG)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/Little/" + slider.SliderIMG));
                    }
                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "slider";


                    WebImage img = new WebImage(file.InputStream);

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 1200)
                        img.Resize(1000, 1000);
                    img.Save("~/Content/images/Little/" + imgsrc2);
                    slider.SliderIMG = imgsrc2;


                }
                db = new UnitOfWork();
                db.SliderRepository.Update(slider);
                db.SliderRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            Slider slider = db.SliderRepository.GetById(id);
            db.SliderRepository.Delete(slider);
            db.SliderRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
