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
    public class SocialsController : Controller
    {
      

            private UnitOfWork db;


            public ActionResult Index()
            {
                db = new UnitOfWork();
                var city = db.SocialRepository.GetAll();
                db.Dispose();
                return View(city);
            }



            public ActionResult Create()
            {
                return PartialView();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Social social,HttpPostedFileBase file)
            {
                if (ModelState.IsValid)
                {
                if (file != null)
                {

                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "social" + social.SocialName;


                    WebImage img = new WebImage(file.InputStream);

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 210)
                        img.Resize(200, 200);
                    img.Save("~/Content/images/social/" + imgsrc2);
                    social.SocialIcon = imgsrc2;


                }
                db = new UnitOfWork();
                    db.SocialRepository.Insert(social);
                    db.SocialRepository.Save();
                    db.Dispose();
                    return RedirectToAction("Index");
                }

                return PartialView(social);
            }


            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db = new UnitOfWork();
                Social social = db.SocialRepository.GetById(id);
                db.Dispose();
                if (social == null)
                {
                    return HttpNotFound();
                }
                return PartialView(social);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Social social, HttpPostedFileBase file)
            {
                if (ModelState.IsValid)
                {
                if (file != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Content/images/social/" + social.SocialIcon)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/social/" + social.SocialIcon));
                    }

                    Random random = new Random();


                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "social" + social.SocialName;


                    WebImage img = new WebImage(file.InputStream);

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 210)
                        img.Resize(200, 200);
                    img.Save("~/Content/images/social/" + imgsrc2);
                    social.SocialIcon = imgsrc2;


                }
                db = new UnitOfWork();
                    db.SocialRepository.Update(social);
                    db.SocialRepository.Save();
                    db.Dispose();
                    return RedirectToAction("Index");
                }
                return View(social);
            }

            public ActionResult Delete(int? id)
            {
                db = new UnitOfWork();
                Social social = db.SocialRepository.GetById(id);
                db.SocialRepository.Delete(social);
                db.SocialRepository.Save();
                db.Dispose();

                return RedirectToAction("Index");
            }
        }
    }

