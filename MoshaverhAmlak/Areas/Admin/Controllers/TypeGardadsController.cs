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
    public class TypeGardadsController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var TypeGardadRepository = db.TypeGardadRepository.GetAll();
            db.Dispose();
            return View(TypeGardadRepository);
        }



        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeGardad typeGarardad)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeGardadRepository.Insert(typeGarardad);
                db.TypeGardadRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return View(typeGarardad);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            TypeGardad typeGarardad = db.TypeGardadRepository.GetById(id);
            db.Dispose();
            if (typeGarardad == null)
            {
                return HttpNotFound();
            }
            return PartialView(typeGarardad);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeGardad typeGarardad)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.TypeGardadRepository.Update(typeGarardad);
                db.TypeGardadRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(typeGarardad);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            TypeGardad typeGarardad = db.TypeGardadRepository.GetById(id);
            db.CityRepository.Delete(typeGarardad);
            db.CityRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
