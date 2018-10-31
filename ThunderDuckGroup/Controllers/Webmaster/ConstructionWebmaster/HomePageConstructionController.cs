using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;

namespace ThunderDuckGroup.Controllers.ThunderDuckConstruction.ConstructionWebmaster
{
    public class HomePageConstructionController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: HomePage
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var home = db.Td_Construction_Slider.Where(st => st.id == 1);
                return View(home);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }

        [HttpPost]
        public ActionResult Edit(string email, string phone, string title, string subtitle, string title1, string subtitle1, string title2, string subtitle2, HttpPostedFileBase logo, HttpPostedFileBase Images, HttpPostedFileBase Images1, HttpPostedFileBase Images2)
        {
            if (Session["Authentication"] != null)
            {
                string log = "";
                if (logo != null)
                {
                            if (logo.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(logo.FileName);
                                var fname = filename.Replace(" ", ",");
                                var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                                logo.SaveAs(path);
                                log += fname;
                            }
                }

                string images = "";
                if (Images != null)
                {
                    if (Images.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                        Images.SaveAs(path);
                        images += fname;
                    }
                }

                string images2 = "";
                if (Images2 != null)
                {
                    if (Images2.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images2.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                        Images2.SaveAs(path);
                        images2 += fname;
                    }
                }

                string images1 = "";
                if (Images1 != null)
                {
                    if (Images1.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images1.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                        Images1.SaveAs(path);
                        images1 += fname;
                    }
                }
                var home = db.Td_Construction_Slider.Find(1);
                home.Email = email;
                home.Phone = phone;
                if (log != "")
                {
                    home.Logo =log;
                }

                if (images != "")
                {
                    home.Images = images;
                }
                if (images2 != "")
                {
                    home.Images2 = images2;
                }
                if (images1 != "")
                {
                    home.Images1 = images1;
                }
                home.Title = title;
                home.Subtitle = subtitle;
                home.Title1 = title1;
                home.Subtitle1 = subtitle1;
                home.Title2 = title2;
                home.Subtitle2 = subtitle2;
                db.Entry(home).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
    }
}