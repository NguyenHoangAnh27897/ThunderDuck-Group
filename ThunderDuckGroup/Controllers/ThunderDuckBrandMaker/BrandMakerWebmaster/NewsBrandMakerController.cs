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
    public class NewsBrandMakerController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: NewsBrandMaker
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var home = db.Td_BrandMaker_News.ToList();
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
                var lst = db.Td_BrandMaker_News.ToList();
                return View(lst);
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        [HttpPost]
        public ActionResult Create(string title, string des, HttpPostedFileBase images)
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
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageNew"), fname);
                        images.SaveAs(path);
                        Images += fname;
                    }
                }

                var ls = new Td_BrandMaker_News();
                ls.Title = title;
                ls.Description = des;
                if (Images != "")
                {
                    ls.Images = Images;
                }
                db.Td_BrandMaker_News.Add(ls);
                db.SaveChanges();

                return RedirectToAction("List", "NewsBrandMaker");
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        public ActionResult Edit(int id)
        {
            var nw1 = db.Td_BrandMaker_News.Where(st => st.id == id);
            News data = new News();
            List<News> ls = new List<News>();
            data.newsss = nw1;
            ls.Add(data);
            return View(ls);
        }
        [HttpPost]
        public ActionResult Edit(string id, string title, string des, HttpPostedFileBase images)
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
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageNew"), fname);
                        images.SaveAs(path);
                        Images += fname;
                    }
                }
                int ID = int.Parse(id);
                var ls = db.Td_BrandMaker_News.Find(ID);
                ls.Title = title;
                ls.Description = des;
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
                var news = db.Td_BrandMaker_News.Find(id);
                db.Entry(news).State = System.Data.Entity.EntityState.Deleted;
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