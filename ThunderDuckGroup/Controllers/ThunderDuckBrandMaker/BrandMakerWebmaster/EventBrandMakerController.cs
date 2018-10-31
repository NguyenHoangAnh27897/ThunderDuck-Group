using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace ThunderDuckGroup.Controllers.ThunderDuckBrandMaker.BrandMakerWebmaster
{
    public class EventBrandMakerController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: EventBrandMaker
         public ActionResult List(int? page =1 )
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var home = db.Td_BrandMaker_Events.ToList();
                return View(home.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }

        }

        public ActionResult Create()
        {
            if (Session["Authentication"] != null)
            {
                var type = db.Td_BrandMaker_AreaType.ToList();
                return View(type);
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        [HttpPost]
        public ActionResult Create(string title, string des, string price, string amount, string typeevent, HttpPostedFileBase images)
        {
            if (Session["Authentication"] != null)
            {

                string Images = "";
                if (images != null)
                {
                    if (images.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(images.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                        images.SaveAs(path);
                        Images += fname;
                    }
                    
                }
                int typee = int.Parse(typeevent);
                var ls = new Td_BrandMaker_Events();
                ls.Title = title;
                ls.Price = price;
                ls.Description = des;
                ls.Amount = amount;
                ls.TypeId = typee;
                if (Images != "")
                {
                    ls.Images = Images;
                }
                db.Td_BrandMaker_Events.Add(ls);
                db.SaveChanges();

                return RedirectToAction("List", "EventBrandMaker");
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Authentication"] != null)
            {
                var typ = db.Td_BrandMaker_Events.Find(id);
                db.Entry(typ).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        public ActionResult Edit(int id)
        {
            var eve = db.Td_BrandMaker_Events.Where(st => st.id == id);
            var typ = db.Td_BrandMaker_AreaType.ToList();
            Event data = new Event();
            data.events = eve;
            data.area = typ;
            List<Event> ls = new List<Event>();
            ls.Add(data);
            return View(ls);
        }
        [HttpPost]
        public ActionResult Edit(string id, string title, string des, string price, string amount, string typeevent, HttpPostedFileBase images)
        {

            if (Session["Authentication"] != null)
            {

                string Images = "";
                if (images != null)
                {
                    if (images.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(images.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                        images.SaveAs(path);
                        Images += fname;
                    }
                }
                int ID = int.Parse(id);
                int typequa = int.Parse(typeevent);
                var ls = db.Td_BrandMaker_Events.Find(ID);
                ls.Title = title;
                ls.Price = price;
                ls.Description = des;
                ls.Amount = amount;
                ls.TypeId = typequa;
                if (Images != "")
                {
                    ls.Images = Images;
                }
                db.Entry(ls).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

    }
}