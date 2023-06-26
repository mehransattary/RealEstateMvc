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
    public class ItemMenusController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index(int? id)
        {
            if (id != 0)
            {
                Session["ZirMenuId"] = id;
                db = new UnitOfWork();
                var itemmenu = db.ItemMenuRepository.GetAll(x => x.ZirmenuId == id);
                ViewBag.ItemNameId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
                db.Dispose();
                return View(itemmenu);
            }
            else
            {

                db = new UnitOfWork();
                var itemmenu = db.ItemMenuRepository.GetAll();
                db.Dispose();
                return View(itemmenu);
            }

        }



        public ActionResult Create(int id = 0)
        {

            id = Convert.ToInt32(Session["ZirMenuId"]);
            if (id != 0)
            {
                db = new UnitOfWork();
                ViewBag.ZirmenuId = new SelectList(db.ZirMenuRepository.GetAll(x => x.Id == id), "Id", "zirMenuName");
                ViewBag.ItemNameId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
                db.Dispose();
                return PartialView();

            }
            else
            {
                db = new UnitOfWork();
                ViewBag.ZirmenuId = new SelectList(db.ZirMenuRepository.GetAll(), "Id", "zirMenuName");
                ViewBag.ItemNameId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
                db.Dispose();
                return PartialView();
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemMenu itemmenu)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                var itemname = db.TypeMelkRepository.GetAll(x => x.Id == itemmenu.ItemNameId).FirstOrDefault().typemelkname;
                itemmenu.ItemName = itemname;
                db.ItemMenuRepository.Insert(itemmenu);
                db.ItemMenuRepository.Save();
                db.Dispose();
                return RedirectToAction("Index", new { id = itemmenu.ZirmenuId });
            }

            return PartialView(itemmenu);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
            ViewBag.ZirmenuId = new SelectList(db.ZirMenuRepository.GetAll(x => x.Id == id), "Id", "zirMenuName");
            ViewBag.ItemNameId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");

            ItemMenu itemmenu = db.ItemMenuRepository.GetById(id);
            db.Dispose();
            if (itemmenu == null)
            {
                return HttpNotFound();
            }
            return PartialView(itemmenu);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemMenu itemmenu)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                var itemname = db.TypeMelkRepository.GetAll(x => x.Id == itemmenu.ItemNameId).FirstOrDefault().typemelkname;
                itemmenu.ItemName = itemname;
                db.ItemMenuRepository.Update(itemmenu);
                db.ItemMenuRepository.Save();
                db.Dispose();
                return RedirectToAction("Index", new { id = itemmenu.ZirmenuId });
            }
            return View(itemmenu);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            ItemMenu itemmenu = db.ItemMenuRepository.GetById(id);
            db.ItemMenuRepository.Delete(itemmenu);
            db.ItemMenuRepository.Save();
            db.Dispose();

            return RedirectToAction("Index");
        }
    }
}
