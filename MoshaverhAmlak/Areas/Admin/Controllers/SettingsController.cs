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
    public class SettingsController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()

        {
          
                db = new UnitOfWork();
                var setting = db.SettingRepository.GetAll();
                db.Dispose();
                return View(setting);
       
        

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Setting setting = db.SettingRepository.GetById(id.Value);
            db.Dispose();
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }


        public ActionResult Create()
        {              
           return PartialView();      
         }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Setting setting, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    Random random = new Random();
                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "setting";                


                    WebImage img = new WebImage(file.InputStream);
                    

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 300)
                        img.Resize(200, 200);
                    img.Save("~/Content/images/Little/" + imgsrc2);
                    setting.imageSrc = imgsrc2;


                }
                db = new UnitOfWork();
                db.SettingRepository.Insert(setting);
                db.SettingRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return View(setting);
        }


        public ActionResult Edit(int? id)
        {
            db = new UnitOfWork();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }




            Setting setting = db.SettingRepository.GetById(id.Value);
                db.Dispose();
                return PartialView(setting);
        



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Setting setting, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/Little/" + setting.imageSrc)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/Little/" + setting.imageSrc));
                    }
                    Random random = new Random();
                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "setting";


                    WebImage img = new WebImage(file.InputStream);


                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 300)
                        img.Resize(200, 200);
                    img.Save("~/Content/images/Little/" + imgsrc2);
                    setting.imageSrc = imgsrc2;


                }
                db = new UnitOfWork();
                db.SettingRepository.Update(setting);
                db.SettingRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            Setting setting = db.SettingRepository.GetById(id);
            db.SettingRepository.Delete(setting);
            db.SettingRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
