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
    public class UsualQuestionsController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index()
        {
            db = new UnitOfWork();
            var usual = db.UsualQuestionRepository.GetAll();
            db.Dispose();
            return View(usual);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            UsualQuestion usual = db.UsualQuestionRepository.GetById(id);
            db.Dispose();
            if (usual == null)
            {
                return HttpNotFound();
            }
            return View(usual);
        }


        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsualQuestion usual)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.UsualQuestionRepository.Insert(usual);
                db.UsualQuestionRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }

            return PartialView(usual);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            UsualQuestion usual = db.UsualQuestionRepository.GetById(id);
            db.Dispose();
            if (usual == null)
            {
                return HttpNotFound();
            }
            return PartialView(usual);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsualQuestion usual)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                db.UsualQuestionRepository.Update(usual);
                db.UsualQuestionRepository.Save();
                db.Dispose();
                return RedirectToAction("Index");
            }
            return View(usual);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            UsualQuestion usual = db.UsualQuestionRepository.GetById(id);
            db.UsualQuestionRepository.Delete(usual);
            db.UsualQuestionRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
