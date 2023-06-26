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

namespace MoshaverhAmlak.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MenusController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var city = db.MenuRepository.GetAll();
            db.Dispose();
            return View(city);
        }



        public ActionResult Create()
        {
            db = new UnitOfWork();
        
            db.Dispose();
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
            
            
                db.MenuRepository.Insert(menu);
                db.MenuRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return PartialView(menu);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            Menu menu = db.MenuRepository.GetById(id);
            db.Dispose();
            if (menu == null)
            {
                return HttpNotFound();
            }
            return PartialView(menu);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.MenuRepository.Update(menu);
                db.MenuRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            Menu menu = db.MenuRepository.GetById(id);
            db.MenuRepository.Delete(menu);
            db.MenuRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
