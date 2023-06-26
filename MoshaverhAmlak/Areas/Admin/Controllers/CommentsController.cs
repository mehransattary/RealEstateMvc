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
using MoshaverhAmlak.Classes;
using PagedList;

namespace MoshaverhAmlak.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

  
     
        public ActionResult Index(int? page = 1)
        {
            var comments = db.Comments.Include(c => c.melk).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Index", comments.OrderBy(x => x.Id).ToPagedList((int)page, 18));
            }
            return View(comments.OrderBy(x => x.Id).ToPagedList((int)page, 18));
        }

    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            ViewBag.MelkId = new SelectList(db.Melks, "Id", "Title");
          
            return View();
        }

        public ActionResult answer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            ViewBag.MelkId = comment.Id;
            ViewBag.ProductId = comment.MelkId;
            ViewBag.MelkName = comment.melk.Title;
            ViewBag.ParentId = comment.Id;
            ViewBag.ParentContent = comment.TextComment;
            ViewBag.Email = comment.Email;
            ViewBag.Name = comment.Name;
            ViewBag.Date = comment.Date;
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult answer(Comment Comments)
        {
            if (ModelState.IsValid)
            {
             
                Comment model = new Comment()
                {
                    Id = Comments.Id + 1,
                    MelkId = Comments.MelkId,
                    ParentId = Comments.Id,
                    TextComment = Comments.TextComment,
                    Name = "مدیر",                 
                    Email = "admin@gmail.com",
                    IsShow = Comments.IsShow,
                    Order = Comments.Id
                };

                db.Comments.Add(model);
                db.SaveChanges();

                var model2 = db.Comments.Where(x => x.Id == model.ParentId).FirstOrDefault();
                model2.OkAnswer = true;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.MelkId = new SelectList(db.Melks, "Id", "Title");
            return View(Comments);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MelkId = new SelectList(db.Melks, "Id", "Title", comment.MelkId);
       
            return View(comment);
        }

   
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.MelkId = new SelectList(db.Melks, "Id", "Title", comment.MelkId);
        
            return View(comment);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MelkId = new SelectList(db.Melks, "Id", "Title", comment.MelkId);
         
            return View(comment);
        }

  
        public ActionResult Delete(int? id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

      
    }
}
