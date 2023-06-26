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
    public class TypeMahdodesController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var TypeGardadRepository = db.TypeMahdodeRepository.GetAll();
            db.Dispose();
            return View(TypeGardadRepository);
        }



        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeMahdode typeMahdode)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeMahdodeRepository.Insert(typeMahdode);
                db.TypeMahdodeRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return View(typeMahdode);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            TypeMahdode typeMahdode = db.TypeMahdodeRepository.GetById(id);
            db.Dispose();
            if (typeMahdode == null)
            {
                return HttpNotFound();
            }
            return PartialView(typeMahdode);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeMahdode typeMahdode)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeMahdodeRepository.Update(typeMahdode);
                db.TypeMahdodeRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(typeMahdode);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            TypeMahdode typeMahdode = db.TypeMahdodeRepository.GetById(id);
            db.TypeMahdodeRepository.Delete(typeMahdode);
            db.TypeMahdodeRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
