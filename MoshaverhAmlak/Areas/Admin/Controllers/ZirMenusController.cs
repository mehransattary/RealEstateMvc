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
    public class ZirMenusController : Controller
    {
        private UnitOfWork db;


        public ActionResult Index(int? id)
        {
            if(id!=0)
            {
              Session["MenuId"] = id;
              db = new UnitOfWork();
              var ZirMenu = db.ZirMenuRepository.GetAll(x=>x.MenuId==id);
           
                db.Dispose();
              return View(ZirMenu);
            }
            else
            {
                
                db = new UnitOfWork();
                var ZirMenu = db.ZirMenuRepository.GetAll();
                db.Dispose();
                return View(ZirMenu);
            }
          
        }



        public ActionResult Create(int id=0)
        {

            id =Convert.ToInt32(Session["MenuId"]);
            if(id!=0)
            {
                db = new UnitOfWork();
                ViewBag.zirMenuNameId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");            
                ViewBag.MenuId = new SelectList(db.MenuRepository.GetAll(x => x.Id==id ), "Id", "MenuName");
                db.Dispose();
                return PartialView();

            }
            else
            {
                db = new UnitOfWork();
                ViewBag.zirMenuNameId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");
                ViewBag.MenuId = new SelectList(db.MenuRepository.GetAll(), "Id", "MenuName");
               db.Dispose();
               return PartialView();
            }
         
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZirMenu zirmenu)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                var zirmenuname = db.TypeCustumerRepository.GetAll(x => x.Id == zirmenu.zirMenuNameId).FirstOrDefault().Custumer;
                zirmenu.zirMenuName = zirmenuname;
               
                db.ZirMenuRepository.Insert(zirmenu);
                db.ZirMenuRepository.Save();
                db.Dispose();
                return RedirectToAction("Index",new { id=zirmenu.MenuId});
            }

            return PartialView(zirmenu);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new UnitOfWork();
           int idmenu = Convert.ToInt32(Session["MenuId"]);
            ViewBag.MenuId = new SelectList(db.MenuRepository.GetAll(x => x.Id == idmenu), "Id", "MenuName");
            ViewBag.zirMenuNameId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");
            ZirMenu zirmenu = db.ZirMenuRepository.GetById(id);
            db.Dispose();
            if (zirmenu == null)
            {
                return HttpNotFound();
            }
            return PartialView(zirmenu);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZirMenu zirmenu)
        {
            if (ModelState.IsValid)
            {
                db = new UnitOfWork();
                var zirmenuname = db.TypeCustumerRepository.GetAll(x => x.Id == zirmenu.zirMenuNameId).FirstOrDefault().Custumer;
                zirmenu.zirMenuName = zirmenuname;
                db.ZirMenuRepository.Update(zirmenu);
                db.ZirMenuRepository.Save();
                db.Dispose();
                return RedirectToAction("Index", new { id = zirmenu.MenuId });
            }
            return View(zirmenu);
        }

        public ActionResult Delete(int? id)
        {
            db = new UnitOfWork();
            ZirMenu zirmenu = db.ZirMenuRepository.GetById(id);
            db.ZirMenuRepository.Delete(zirmenu);
            db.ZirMenuRepository.Save();
            db.Dispose();

            return RedirectToAction("Index",new { id=zirmenu.MenuId});
        }
    }
}
