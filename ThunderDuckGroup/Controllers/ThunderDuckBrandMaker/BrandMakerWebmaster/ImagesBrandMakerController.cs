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
    public class ImagesBrandMakerController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: ImagesBrandMaker
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                var pageSize = 7;
                int pageNumber = (page ?? 7);
                var lst = db.Td_BrandMaker_Images.ToList();
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["Authentication"] != null)
            {
                var mb = db.Td_BrandMaker_Images.Where(st => st.id == id);
                return View(mb);
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, string title, string subtitle, HttpPostedFileBase[] Images1)
        {
            if (Session["Authentication"] != null)
            {
                string Images = "";
                if (Images1 != null)
                {
                    foreach (HttpPostedFileBase file in Images1)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(file.FileName);
                                var fname = filename.Replace(" ", "_");
                                var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                                file.SaveAs(path);
                                Images += fname + ",";
                            }
                        }
                    }
                    if (Images != "" && Images.Contains(","))
                    {
                        Images = Images.Remove(Images.Length - 1);
                    }
                }
                int ID = int.Parse(id);
                var home = db.Td_BrandMaker_Images.Find(ID);
                home.Subtitle = subtitle;
                home.Title = title;
                if (Images != "")
                {
                    home.images1 = Images;
                }
                db.Entry(home).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
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
                var lst = db.Td_BrandMaker_Images.ToList();
                return View(lst);
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        [HttpPost]
        public ActionResult Create(string title, string subtitle, HttpPostedFileBase[] images)
        {
            if (Session["Authentication"] != null)
            {
                string Images = "";
                if (images != null)
                {
                    foreach (HttpPostedFileBase file in images)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(file.FileName);
                                var fname = filename.Replace(" ", ",");
                                var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                                file.SaveAs(path);
                                Images += fname;
                            }
                        }
                    }
                    if (Images != "" && Images.Contains(","))
                    {
                        Images = Images.Remove(Images.Length - 1);
                    }
                }

                var home = new Td_BrandMaker_Images();
                home.Title = title;
                home.Subtitle = subtitle;
                if (Images != null)
                {
                    home.images1 = Images;
                }
                db.Td_BrandMaker_Images.Add(home);
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
                var mems = db.Td_BrandMaker_Images.Find(id);
                db.Entry(mems).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List", "ImagesBrandMaker");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }

    }
}