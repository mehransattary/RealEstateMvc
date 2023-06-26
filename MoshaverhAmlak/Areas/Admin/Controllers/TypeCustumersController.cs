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
    public class TypeCustumersController : Controller
    {
      

        private UnitOfWork db;


            public ActionResult Index()
            {
                db = new UnitOfWork();
                var city = db.TypeCustumerRepository.GetAll();
                db.Dispose();
                return View(city);
            }



            public ActionResult Create()
            {
                return PartialView();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(TypeCustumer typeCustumer)
            {
                if (ModelState.IsValid)
                {
                    db = new UnitOfWork();
                    db.TypeCustumerRepository.Insert(typeCustumer);
                    db.TypeCustumerRepository.Save();
                    db.Dispose();
                    return RedirectToAction("Index");
                }

                return View(typeCustumer);
            }


            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db = new UnitOfWork();
                TypeCustumer tcustumer = db.TypeCustumerRepository.GetById(id);
                db.Dispose();
                if (tcustumer == null)
                {
                    return HttpNotFound();
                }
                return PartialView(tcustumer);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(TypeCustumer typeCustumer)
            {
                if (ModelState.IsValid)
                {
                    db = new UnitOfWork();
                    db.TypeCustumerRepository.Update(typeCustumer);
                    db.TypeCustumerRepository.Save();
                    db.Dispose();
                    return RedirectToAction("Index");
                }
                return View(typeCustumer);
            }

            public ActionResult Delete(int? id)
            {
                db = new UnitOfWork();
                TypeCustumer tcustumer = db.TypeCustumerRepository.GetById(id);
                db.CityRepository.Delete(tcustumer);
                db.CityRepository.Save();
                db.Dispose();

                return RedirectToAction("Index");
            }
        }
}
