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
    public class TypeMelksController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var TypeMelkRepository = db.TypeMelkRepository.GetAll();
            db.Dispose();
            return View(TypeMelkRepository);
        }



        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeMelk typeMelk)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeMelkRepository.Insert(typeMelk);
                db.TypeMelkRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return View(typeMelk);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            TypeMelk TypeMelkRepository = db.TypeMelkRepository.GetById(id);
            db.Dispose();
            if (TypeMelkRepository == null)
            {
                return HttpNotFound();
            }
            return PartialView(TypeMelkRepository);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeMelk typeMelk)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeMelkRepository.Update(typeMelk);
                db.TypeMelkRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(typeMelk);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            TypeMelk typeMelk = db.TypeMelkRepository.GetById(id);
            db.TypeMelkRepository.Delete(typeMelk);
            db.TypeMelkRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
