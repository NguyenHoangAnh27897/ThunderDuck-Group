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
    public class ConsConstructionMasterController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: ConsConstructionMaster
        public ActionResult List(int ? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lis = db.Td_Construction_Construction.ToList();
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
                var lis = db.Td_Construction_Construction.ToList();
                return View(lis);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }

        }
        [HttpPost]
        public ActionResult Create(string tenxd, string mota,HttpPostedFileBase[] image, HttpPostedFileBase ava)
        {

            if (Session["Authentication"] != null)
            {

                string Image = "";
                if (image != null)
                {
                    foreach (HttpPostedFileBase file in image)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(file.FileName);
                                var fname = filename.Replace(" ", "_");
                                var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageHome"), fname);
                                file.SaveAs(path);
                                Image += fname + ",";
                            }
                        }
                    }
                    if (Image != "" && Image.Contains(","))
                    {
                        Image = Image.Remove(Image.Length - 1);
                    }
                }
                string Avat = "";
                if (ava != null)
                {
                    if (ava.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(ava.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageHome"), fname);
                        ava.SaveAs(path);
                        Avat += fname;
                    }
                }

                var ls = new Td_Construction_Construction();
                ls.Title = tenxd;
                ls.Description = mota;
                
                if (Image != "")
                {
                    ls.Images = Image;
                }
                if (Avat != "")
                {
                    ls.Avatar = Avat;
                }
                db.Td_Construction_Construction.Add(ls);
                db.SaveChanges();

                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
        public ActionResult Edit(int iD)
        {
            if (Session["Authentication"] != null)
            {
                var lis = db.Td_Construction_Construction.Where(st => st.id == iD);
                return View(lis);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
        [HttpPost]
        public ActionResult Edit(string ID,string tenxd, string mota, HttpPostedFileBase[] image, HttpPostedFileBase ava)
        {
            if (Session["Authentication"] != null)
            {

                string Image = "";
                if (image != null)
                {
                    foreach (HttpPostedFileBase file in image)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(file.FileName);
                                var fname = filename.Replace(" ", "_");
                                var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageHome"), fname);
                                file.SaveAs(path);
                                Image += fname + ",";
                            }
                        }
                    }
                    if (Image != "" && Image.Contains(","))
                    {
                        Image = Image.Remove(Image.Length - 1);
                    }
                }
                string Avat = "";
                if (ava != null)
                {
                    if (ava.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(ava.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageHome"), fname);
                        ava.SaveAs(path);
                        Avat += fname;
                    }
                }
                int id = int.Parse(ID);
                var ls = db.Td_Construction_Construction.Find(id);
                ls.Title = tenxd;
                ls.Description = mota;

                if (Image != "")
                {
                    ls.Images = Image;
                }
                if (Avat != "")
                {
                    ls.Avatar = Avat;
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Authentication"] != null)
            {
                var cons = db.Td_Construction_Construction.Find(id);
                db.Entry(cons).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
    }
}