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
    public class TypeSanadsController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var TypeSanadRepository = db.TypeSanadRepository.GetAll();
            db.Dispose();
            return View(TypeSanadRepository);
        }



        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeSanad typesanad)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeSanadRepository.Insert(typesanad);
                db.TypeSanadRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return View(typesanad);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            TypeSanad TypeSanadRepository = db.TypeSanadRepository.GetById(id);
            db.Dispose();
            if (TypeSanadRepository == null)
            {
                return HttpNotFound();
            }
            return PartialView(TypeSanadRepository);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeSanad typesanad)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeSanadRepository.Update(typesanad);
                db.TypeSanadRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(typesanad);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            TypeSanad TypeSanadRepository = db.TypeSanadRepository.GetById(id);
            db.TypeSanadRepository.Delete(TypeSanadRepository);
            db.TypeSanadRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
