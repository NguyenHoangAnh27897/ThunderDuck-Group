using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;

namespace ThunderDuckGroup.Controllers.ThunderDuckConstruction.ConstructionWebmaster
{
    public class StoryConstructionController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: StoryConstruction
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var home = db.Td_Constrution_Story.Where(st => st.id == 1);
                return View(home);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }

        [HttpPost]
        public ActionResult Edit(string title, string des, string des1, HttpPostedFileBase images, HttpPostedFileBase sign)
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

                string Sign = "";
                if (sign != null)
                {
                    if (sign.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(sign.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/ThunderDuckGroup/imageHome"), fname);
                        sign.SaveAs(path);
                        Sign += fname;
                    }
                }

                var st = db.Td_Constrution_Story.Find(1);
                st.Title = title;
                st.Description = des;
                st.Description1 = des1;
                if (Images != "")
                {
                    st.Images = Images;
                }
                if (Sign != "")
                {
                    st.Signature = Sign;
                }
                db.Entry(st).State = System.Data.Entity.EntityState.Modified;
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