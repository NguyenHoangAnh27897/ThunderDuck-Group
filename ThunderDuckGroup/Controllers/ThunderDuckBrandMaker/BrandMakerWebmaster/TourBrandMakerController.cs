using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
using PagedList.Mvc;
using PagedList;
namespace ThunderDuckGroup.Controllers.ThunderDuckBrandMaker.BrandMakerWebmaster
{
    public class TourBrandMakerController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: TourBrandMaker
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lst = db.Td_BrandMaker_Tours.ToList();
                return View(lst.ToPagedList(pageNumber, pageSize));
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
                var lst = db.Td_BrandMaker_Tours.ToList();
                return View(lst);
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        [HttpPost]
        public ActionResult Create(string title, string des, string price, string amount, HttpPostedFileBase images)
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

                var ls = new Td_BrandMaker_Tours();
                ls.Title = title;
                ls.Description = des;
                ls.Price = price;
                ls.Amount = amount;
                if (Images != "")
                {
                    ls.Images = Images;
                }
                db.Td_BrandMaker_Tours.Add(ls);
                db.SaveChanges();

                return RedirectToAction("List", "TourBrandMaker");
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        public ActionResult Edit(int id)
        {
            var tou = db.Td_BrandMaker_Tours.Where(st => st.id == id);
            Tour data = new Tour();
            List<Tour> ls = new List<Tour>();
            data.tours = tou;
            ls.Add(data);
            return View(ls);
        }
        [HttpPost]
        public ActionResult Edit(string id, string title, string des, string price, string amount, HttpPostedFileBase images)
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
                var ls = db.Td_BrandMaker_Tours.Find(ID);
                ls.Title = title;
                ls.Description = des;
                ls.Price = price;
                ls.Amount = amount;
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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Authentication"] != null)
            {
                var tour = db.Td_BrandMaker_Tours.Find(id);
                db.Entry(tour).State = System.Data.Entity.EntityState.Deleted;
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