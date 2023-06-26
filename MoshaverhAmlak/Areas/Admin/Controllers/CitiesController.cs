using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoshaverDataLayer.Model;
using MoshaverDataLayer.Context;

namespace MoshaverhAmlak.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
      
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var city = db.CityRepository.GetAll();
            db.Dispose();
            return View(city);
        }



        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( City city)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.CityRepository.Insert(city);
                db.CityRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return PartialView(city);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            City city = db.CityRepository.GetById(id);
            db.Dispose();
            if (city == null)
            {
                return HttpNotFound();
            }
            return PartialView(city);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( City city)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.CityRepository.Update(city);
                db.CityRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            City city = db.CityRepository.GetById(id);
            db.CityRepository.Delete(city);
            db.CityRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
