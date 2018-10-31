using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
namespace ThunderDuckGroup.Controllers.ThunderDuckBrandMaker.BrandMakerWebmaster
{
    public class HomePageBrandMakerController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: HomePage
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var home = db.Td_BrandMaker_Slider.Where(st => st.id == 1);
                return View(home);
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }

        [HttpPost]
        public ActionResult Edit(string email, string phone, HttpPostedFileBase[] logo, string video, string title, string des)
        {
            if (Session["Authentication"] != null)
            {
                string Images = "";
                if (logo != null)
                {
                    foreach (HttpPostedFileBase file in logo)
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
                var home = db.Td_BrandMaker_Slider.Find(1);
                home.Email = email;
                home.Phone = phone;
                if (Images != null)
                {
                    home.Logo = Images;
                }
                home.Title = title;
                home.Description = des;
                db.Entry(home).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            else
            {
                return RedirectToAction("Login", "WebmasterBrandMaker");
            }
        }
    }
}
