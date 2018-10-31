using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
using PagedList.Mvc;
using PagedList;

namespace ThunderDuckGroup.Controllers.Webmaster.ConstructionWebmaster
{
    public class ImageConstructionMasterController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: ImageConstructionMaster
        public ActionResult List(int ? page = 1)
        {
           
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lis = db.Td_Construction_Images.ToList();
                return View(lis.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
        public ActionResult Create()
        {
            if (Session["Authentication"] != null)
            {
                var lis = db.Td_Construction_Images.ToList();
                return View(lis);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
        [HttpPost]
        public ActionResult Create(string tenhinh, HttpPostedFileBase image)
        {

            if (Session["Authentication"] != null)
            {
                string Img = "";
                if (image != null)
                {
                    if (image.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageimg"), fname);
                        image.SaveAs(path);
                        Img += fname;
                    }
                }

                var ls = new Td_Construction_Images();
                ls.Title = tenhinh;
                if (Img != "")
                {
                    ls.Images = Img;
                }
                db.Td_Construction_Images.Add(ls);
                db.SaveChanges();

                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Authentication"] != null)
            {
                var ne = db.Td_Construction_New.Find(id);
                db.Entry(ne).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
        public ActionResult Edit(int ID)
        {
            if (Session["Authentication"] != null)
            {
                var lis = db.Td_Construction_Images.Where(st => st.id == ID);
                return View(lis);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
        [HttpPost]
        public ActionResult Edit(string ID, string tenhinh, HttpPostedFileBase image)
        {
            if (Session["Authentication"] != null)
            {
                string Img = "";
                if (image != null)
                {
                    if (image.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageimg"), fname);
                        image.SaveAs(path);
                        Img += fname;
                    }
                }
                int id = int.Parse(ID);
                var ls = db.Td_Construction_Images.Find(id);
                ls.Title = tenhinh;
                if (Img != "")
                {
                    ls.Images = Img;
                }
                db.Entry(ls).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
    }
}