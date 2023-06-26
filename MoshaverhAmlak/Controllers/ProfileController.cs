using MoshaverDataLayer.Context;
using MoshaverDataLayer.Model;
using MoshaverhAmlak.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MoshaverhAmlak.Controllers
{
    [Authorize(Roles = "User")]
    //[Authorize(Users ="mahdi,morteza")]
    //[Authorize(Roles = "Admin,user")]
    public class ProfileController : Controller
    {
        UnitOfWork db;
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowMelk(   int? page = 1)
        {

            ApplicationDbContext db1 = new ApplicationDbContext();
        
            if (User.Identity.IsAuthenticated)
            {
                db = new UnitOfWork();
                var userID = db1.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
                var melk=   db.MelkRepository.GetAll(x => x.userId== userID);
                db.Dispose();
            
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView("_ShowMelk", melk.ToPagedList((int)page, 12));
                    }
                    return View(melk.ToPagedList((int)page, 12));
            
            
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Melk melk = db.MelkRepository.GetById(id);
            db.Dispose();
            if (melk == null)
            {
                return HttpNotFound();
            }
            return View(melk);
        }


  


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Melk melk = db.MelkRepository.GetById(id);
      
            if (melk == null)
            {
                return HttpNotFound();
            }

            ViewBag.cityId = new SelectList(db.CityRepository.GetAll(), "Id", "cityname", melk.cityId);
            ViewBag.typecustumerId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer", melk.typecustumerId);
            ViewBag.typeGardadId = new SelectList(db.TypeGardadRepository.GetAll(), "Id", "typegardadname", melk.typeGardadId);
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodeRepository.GetAll(), "Id", "typemahdodename", melk.typeMahdodeId);
            ViewBag.typeMelkId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname", melk.typeMelkId);
            ViewBag.typeSanadId = new SelectList(db.TypeSanadRepository.GetAll(), "Id", "typesanadname", melk.typeSanadId);
            db.Dispose();
            return View(melk);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Melk melk, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
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
                ApplicationDbContext db1 = new ApplicationDbContext();
                melk.IsShow = false;
                melk.typeWriter = 2;
                melk.userId = db1.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().Id;
         
                db.MelkRepository.Update(melk);
                db.MelkRepository.Save();
                db.Dispose();
                return RedirectToAction("ShowMelk");
            }

            ViewBag.cityId = new SelectList(db.CityRepository.GetAll(), "Id", "cityname", melk.cityId);
            ViewBag.typecustumerId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer", melk.typecustumerId);
            ViewBag.typeGardadId = new SelectList(db.TypeGardadRepository.GetAll(), "Id", "typegardadname", melk.typeGardadId);
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodeRepository.GetAll(), "Id", "typemahdodename", melk.typeMahdodeId);
            ViewBag.typeMelkId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname", melk.typeMelkId);
            ViewBag.typeSanadId = new SelectList(db.TypeSanadRepository.GetAll(), "Id", "typesanadname", melk.typeSanadId);
            return View(melk);
        }


        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            Melk melk = db.MelkRepository.GetById(id);          
            db.MelkRepository.Delete(melk);
            db.MelkRepository.Save();
            db.Dispose();
            return RedirectToAction("Index","Home");
        }



   
    }
}