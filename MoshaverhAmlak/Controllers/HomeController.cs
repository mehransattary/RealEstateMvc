using MoshaverDataLayer.Context;
using MoshaverDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MoshaverDataLayer.ViewModel;
using PagedList;
using MoshaverhAmlak.Models;

namespace MoshaverhAmlak.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork db;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult cretae()
        {

            return View();
        }
        [HttpPost]
        public ActionResult cretae(City city)
        {

            return View();
        }
        public ActionResult About()
        {

            db = new UnitOfWork();
            var setting = db.SettingRepository.GetAll();
            db.Dispose();
            return View(setting);
        }
        public ActionResult UsualQuestions()
        {

            db = new UnitOfWork();
            var usual = db.UsualQuestionRepository.GetAll();
            db.Dispose();
            return PartialView("_UsualQuestions", usual);
        }
        public ActionResult Contact()
        {
            db = new UnitOfWork();
            var setting = db.SettingRepository.GetAll();
            db.Dispose();
            return View(setting);
        }
        public ActionResult Menu()
        {
            db = new UnitOfWork();
            var menus = db.MenuRepository.GetAll();
            db.Dispose();
            return PartialView("_Menu", menus);
        }
        public ActionResult TopMenu()
        {
            db = new UnitOfWork();
            var setting = db.SettingRepository.GetAll().FirstOrDefault();
            db.Dispose();
            return PartialView("_TopMenu", setting);
        }
        public ActionResult Slider()
        {
            db = new UnitOfWork();
            var slider = db.SliderRepository.GetAll();
            db.Dispose();
            return PartialView("_Slider", slider);
        }
        public ActionResult LastMelkShow(int? page = 1)
        {
            db = new UnitOfWork();
            var melk = db.MelkRepository.GetAll(x => x.IsShow == true).OrderBy(x => x.DateCreate);
            db.Dispose();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_LastMelkShow2", melk.ToPagedList((int)page, 9));
            }
          
            return PartialView( melk.ToPagedList((int)page, 9));
        }
        public ActionResult SpacialAmlak()
        {
            db = new UnitOfWork();
            var melk = db.MelkRepository.GetAll(x => x.SpecialAmlak == true && x.IsShow == true).Take(12).OrderBy(x => x.DateCreate);
            db.Dispose();
            return PartialView("_SpacialAmlak", melk);
        }
    
        public ActionResult BrandShow()
        {
            db = new UnitOfWork();
            var brand = db.BrandRepository.GetAll().Take(12).OrderBy(x => x.Id);
            db.Dispose();
            return PartialView("_BrandShow", brand);
        }
        public ActionResult SicialShow()
        {
            db = new UnitOfWork();
            var social = db.SocialRepository.GetAll().Take(12).OrderBy(x => x.SocialOrder);
            db.Dispose();
            return PartialView("_SicialShow", social);
        }
        public ActionResult AdvertiseShow()
        {
            db = new UnitOfWork();
            var adver = db.AdvertiseRepository.GetAll();
            db.Dispose();
            return PartialView("_AdvertiseShow", adver);
        }
        public ActionResult MelkAllShowList(int? id,int? zirMenuNameId, int? page = 1)
        { 
            if (zirMenuNameId != null)
            {
                Session["typemelkid"] = id;
                Session.Timeout = 2;
                //Session.Remove("typemelkid");
              
                db = new UnitOfWork();
                var  melk = db.MelkRepository.GetAll(x => x.typecustumerId == zirMenuNameId && x.IsShow == true);
                if(id != null)
                {
                    melk = db.MelkRepository.GetAll(x => x.typeMelkId == id && x.typecustumerId == zirMenuNameId && x.IsShow == true);
                }          
                         
             

                db.Dispose();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_MelkAllShowList", melk.ToPagedList((int)page, 24));
                }
                return View(melk.ToPagedList((int)page,24));
            }
            else
            {
                db = new UnitOfWork();
                var melk = db.MelkRepository.GetAll(x => x.IsShow == true);
                db.Dispose();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_MelkAllShowList", melk.ToPagedList((int)page,24));
                }
                return View(melk.ToPagedList((int)page, 24));
            }
        }
        public ActionResult MelkAllShowToury(int? id, int? zirMenuNameId, int? page = 1)
        {
            if (id != null)
            {
                db = new UnitOfWork();
                var melk = db.MelkRepository.GetAll(x => x.typeMelkId == id && x.typecustumerId == zirMenuNameId && x.IsShow == true);
                if (zirMenuNameId != 0)
                {
                    melk = db.MelkRepository.GetAll(x => x.typeMelkId == id && x.IsShow == true);
                }

                db.Dispose();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_MelkAllShowList", melk.ToPagedList((int)page, 24));
                }

                return View(melk.ToPagedList((int)page, 24));
            }
            else
            {
                db = new UnitOfWork();
                var melk = db.MelkRepository.GetAll(x => x.IsShow == true);
                db.Dispose();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_MelkAllShowList", melk.ToPagedList((int)page, 24));
                }

                return View(melk.ToPagedList((int)page, 24));
            }

        }
        [Authorize(Roles ="User")]
        public ActionResult InsertMelk(string msg ="")
        {
            if (msg != "")
            {
                ViewBag.succee = "ملک مورد نظر شما با موفقیت ثبت گردید";
            }

            db = new UnitOfWork();
            ViewBag.cityId = new SelectList(db.CityRepository.GetAll(), "Id", "cityname");
            ViewBag.typecustumerId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");
            ViewBag.typeGardadId = new SelectList(db.TypeGardadRepository.GetAll(), "Id", "typegardadname");
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodeRepository.GetAll(), "Id", "typemahdodename");
            ViewBag.typeMelkId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
            ViewBag.typeSanadId = new SelectList(db.TypeSanadRepository.GetAll(), "Id", "typesanadname");
            db.Dispose();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertMelk(Melk melk, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {

                    Random random = new Random();
                    string imgcode = random.Next(100000, 999000).ToString();
                    string imgname = "melk";


                    string imgsrc1 = "large" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/images/Melks/") + imgsrc1);
                    melk.ImgB = imgsrc1;


                    WebImage img = new WebImage(file.InputStream);
                    string imgsrc3 = "Standard" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 900)
                        img.Resize(600, 600);
                    img.Save("~/Content/images/Melks/" + imgsrc3);
                    melk.ImgS = imgsrc3;

                    string imgsrc2 = "small" + "-" + imgname + "-" + imgcode.ToString() + "-" + file.FileName;
                    if (img.Width > 590)
                        img.Resize(400, 400);
                    img.Save("~/Content/images/Melks/" + imgsrc2);
                    melk.ImgL = imgsrc2;


                }
                ApplicationDbContext db1 = new ApplicationDbContext();
                melk.IsShow = false;             
                melk.typeWriter = 2;           
                melk.userId = db1.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault().Id;
                db = new UnitOfWork();
                db.MelkRepository.Insert(melk);
                db.MelkRepository.Save();
                db.Dispose();

                return RedirectToAction("ShowMelk","Profile", new { msg = "ملک مورد نظر شما با موفقیت ثبت گردید" });

            }
            db = new UnitOfWork();
            ViewBag.cityId = new SelectList(db.CityRepository.GetAll(), "Id", "cityname");
            ViewBag.typecustumerId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");
            ViewBag.typeGardadId = new SelectList(db.TypeGardadRepository.GetAll(), "Id", "typegardadname");
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodeRepository.GetAll(), "Id", "typemahdodename");
            ViewBag.typeMelkId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
            ViewBag.typeSanadId = new SelectList(db.TypeSanadRepository.GetAll(), "Id", "typesanadname");
            db.Dispose();
            return View(melk);

        }

        public ActionResult Melk(int? id)
        {
            db = new UnitOfWork();
            ViewBag.cityId = new SelectList(db.CityRepository.GetAll(), "Id", "cityname");
            ViewBag.typecustumerId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");
            ViewBag.typeGardadId = new SelectList(db.TypeGardadRepository.GetAll(), "Id", "typegardadname");
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodeRepository.GetAll(), "Id", "typemahdodename");
            ViewBag.typeMelkId = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
            ViewBag.typeSanadId = new SelectList(db.TypeSanadRepository.GetAll(), "Id", "typesanadname");
            var melk = db.MelkRepository.GetById(id);
            db.Dispose();
            return View(melk);
        }
        public ActionResult ShowZirMenu(int? id)
        {
            db = new UnitOfWork();
            var zirmenu = db.TypeCustumerRepository.GetAll(x => x.Id == id).FirstOrDefault().Id;
            var melk = db.MelkRepository.GetAll(x => x.typecustumerId == zirmenu);
            db.Dispose();
            return RedirectToAction("MelkAllShowList", new { zirMenuNameId = id });
        }
        public ActionResult ShowItemmenu(int? id,int? zirMenuNameId)
        {
            db = new UnitOfWork();
            var itemid = db.TypeMelkRepository.GetAll(x => x.Id == id).FirstOrDefault().Id;
            var melk = db.MelkRepository.GetAll(x => x.typeMelkId == itemid&&x.typecustumerId==zirMenuNameId);
            db.Dispose();
            return RedirectToAction("MelkAllShowList", new { id = id, zirMenuNameId = zirMenuNameId });
        }
        public ActionResult SearchSliderMelk()
        {
            db = new UnitOfWork();
            ViewBag.typemelk = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodeRepository.GetAll(), "Id", "typemahdodename");
            ViewBag.typecustumerId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");
            db.Dispose();
            return PartialView("_SearchSliderMelk");
        }
        public ActionResult SearchSlider()
        {
            db = new UnitOfWork();
            ViewBag.typemelk = new SelectList(db.TypeMelkRepository.GetAll(), "Id", "typemelkname");
            ViewBag.typeMahdodeId = new SelectList(db.TypeMahdodeRepository.GetAll(), "Id", "typemahdodename");
            ViewBag.typecustumerId = new SelectList(db.TypeCustumerRepository.GetAll(), "Id", "Custumer");
            db.Dispose();
            return PartialView("_SearchSlider");
        }
        [HttpPost]
        public ActionResult SearchSlider(SearchViewModel vmodel, int? page = 1)
        {
            db = new UnitOfWork();
            var melk1 = db.MelkRepository.GetAll();
            if (vmodel.typecustumerId!=0 && vmodel.typeMahdodeId==0 && vmodel.typemelk==0)
            {
                melk1 = db.MelkRepository.GetAll(x => x.typecustumerId == vmodel.typecustumerId );
            }
            if (vmodel.typecustumerId == 0 && vmodel.typeMahdodeId != 0 && vmodel.typemelk == 0)
            {
                 melk1 = db.MelkRepository.GetAll(x => x.typeMahdodeId == vmodel.typeMahdodeId);
            }
            if (vmodel.typecustumerId == 0 && vmodel.typeMahdodeId == 0 && vmodel.typemelk != 0)
            {
              melk1 = db.MelkRepository.GetAll(x => x.typeMelkId == vmodel.typemelk);
            }
            if (vmodel.typecustumerId != 0 && vmodel.typeMahdodeId != 0 && vmodel.typemelk == 0)
            {
                 melk1 = db.MelkRepository.GetAll(x => x.typecustumerId == vmodel.typecustumerId&&x.typeMahdodeId==vmodel.typeMahdodeId);
            }
            if (vmodel.typecustumerId == 0 && vmodel.typeMahdodeId != 0 && vmodel.typemelk != 0)
            {
                melk1 = db.MelkRepository.GetAll(x => x.typeMelkId == vmodel.typemelk && x.typeMahdodeId == vmodel.typeMahdodeId);
            }
            if (vmodel.typecustumerId != 0 && vmodel.typeMahdodeId == 0 && vmodel.typemelk != 0)
            {
               melk1 = db.MelkRepository.GetAll(x => x.typeMelkId == vmodel.typemelk && x.typecustumerId == vmodel.typecustumerId);
            }
            if (vmodel.typecustumerId != 0 && vmodel.typeMahdodeId != 0 && vmodel.typemelk != 0)
            {
                melk1 = db.MelkRepository.GetAll(x => x.typecustumerId == vmodel.typecustumerId && x.typeMahdodeId == vmodel.typeMahdodeId && x.typeMelkId == vmodel.typemelk);
            }    
       
             
        
         
            List<SearchCartViewModel> shopcart = new List<SearchCartViewModel>();
            foreach (var item1 in melk1)            {

                if (vmodel.PriceFirst != 0&&vmodel.PriceEnd==0&&vmodel.MinMeter==0&&vmodel.MaxMeter==0)
                {
                    if (item1.PriceAll >vmodel.PriceFirst)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter == 0 && vmodel.MaxMeter == 0)
                {
                    if (item1.PriceAll < vmodel.PriceEnd)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd== 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter == 0)
                {
                    if (item1.Meter > vmodel.MinMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd == 0 && vmodel.MinMeter == 0 && vmodel.MaxMeter != 0)
                {
                    if (item1.Meter < vmodel.MaxMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst != 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter == 0 && vmodel.MaxMeter == 0)
                {
                    if (item1.PriceAll> vmodel.PriceFirst  &&   item1.PriceAll<vmodel.PriceEnd)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter == 0)
                {
                    if (item1.Meter > vmodel.MinMeter && item1.PriceAll < vmodel.PriceEnd)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd == 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter != 0)
                {
                    if (item1.Meter > vmodel.MinMeter && item1.Meter < vmodel.MaxMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst != 0 && vmodel.PriceEnd == 0 && vmodel.MinMeter == 0 && vmodel.MaxMeter != 0)
                {
                    if (item1.PriceAll > vmodel.PriceFirst && item1.Meter < vmodel.MaxMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter == 0 && vmodel.MaxMeter != 0)
                {
                    if (item1.Meter <vmodel.MaxMeter && item1.PriceAll < vmodel.PriceEnd)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst != 0 && vmodel.PriceEnd == 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter == 0)
                {
                    if (item1.Meter > vmodel.MinMeter && item1.PriceAll > vmodel.PriceFirst)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst != 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter == 0)
                {
                    if (item1.PriceAll > vmodel.PriceFirst && item1.PriceAll < vmodel.PriceEnd  &&  item1.Meter>vmodel.MinMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter != 0)
                {
                    if (item1.Meter > vmodel.MaxMeter && item1.PriceAll < vmodel.PriceEnd && item1.Meter > vmodel.MinMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst != 0 && vmodel.PriceEnd == 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter == 0)
                {
                    if (item1.PriceAll > vmodel.PriceFirst && item1.Meter < vmodel.MaxMeter && item1.Meter > vmodel.MinMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst != 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter == 0 && vmodel.MaxMeter != 0)
                {
                    if (item1.PriceAll > vmodel.PriceFirst && item1.PriceAll < vmodel.PriceEnd && item1.Meter < vmodel.MaxMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst != 0 && vmodel.PriceEnd != 0 && vmodel.MinMeter != 0 && vmodel.MaxMeter != 0)
                {
                    if (item1.PriceAll > vmodel.PriceFirst && item1.PriceAll < vmodel.PriceEnd && item1.Meter < vmodel.MaxMeter&&item1.Meter>vmodel.MinMeter)
                    {
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });
                    }
                }
                if (vmodel.PriceFirst == 0 && vmodel.PriceEnd == 0 && vmodel.MinMeter == 0 && vmodel.MaxMeter == 0)
                {
                   
                        shopcart.Add(new SearchCartViewModel()
                        {
                            Title = item1.Title,
                            emkanat = item1.typeEmkanatId,
                            MelkId = item1.Id,
                            melkimgL = item1.ImgS,
                            melkimgS = item1.ImgL,
                            melkimgB = item1.ImgB,
                            Rooms = item1.Rooms,
                            Wc = item1.Wc,
                            Meter = item1.Meter,
                            PriceAll = item1.PriceAll,
                            typemelk = item1.typeMelkId,
                            cityID = item1.cityId
                        });                  
                }
            }
               Session["melk"] = shopcart;
                db.Dispose();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ResultSearch", shopcart.ToPagedList((int)page, 5));
            }
            return View("ResultSearch", shopcart.ToPagedList((int)page, 5));

           
             
            }


       
    }
    }
