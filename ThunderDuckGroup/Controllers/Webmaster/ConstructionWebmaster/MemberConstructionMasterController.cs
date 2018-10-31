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
    public class MemberConstructionMasterController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: MemberConstructionMaster
        public ActionResult List(int ? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lis = db.Td_Construction_Member.ToList();
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
                var lis = db.Td_Construction_Member.ToList();
                return View(lis);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
        [HttpPost]
        public ActionResult Create(string tentv, string chucvu,string gthieu, HttpPostedFileBase ava)
        {

            if (Session["Authentication"] != null)
            {
                string Avat = "";
                if (ava != null)
                {
                    if (ava.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(ava.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageMembers"), fname);
                        ava.SaveAs(path);
                        Avat += fname;
                    }
                }

                var ls = new Td_Construction_Member();
                ls.Title = tentv;
                ls.Subtitle = chucvu;
                ls.Introduction = gthieu;

              
                if (Avat != "")
                {
                    ls.Images = Avat;
                }
                db.Td_Construction_Member.Add(ls);
                db.SaveChanges();

                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
            
        }
        public ActionResult Edit(int ID)
        {
            if (Session["Authentication"] != null)
            {
                var lis = db.Td_Construction_Member.Where(st => st.id == ID );
                return View(lis);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }
        [HttpPost]
        public ActionResult Edit(string ID, string tentv, string chucvu, string gthieu, HttpPostedFileBase ava)
        {
            if (Session["Authentication"] != null)
            {
                string Avat = "";
                if (ava != null)
                {
                    if (ava.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(ava.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/Thunderduckgroup/imageMembers"), fname);
                        ava.SaveAs(path);
                        Avat += fname;
                    }
                }
                int id = int.Parse(ID);
                var ls = db.Td_Construction_Member.Find(id);
                ls.Title = tentv;
                ls.Subtitle = chucvu;
                ls.Introduction = gthieu;


                if (Avat != "")
                {
                    ls.Images = Avat;
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
                var mem = db.Td_Construction_Member.Find(id);
                db.Entry(mem).State = System.Data.Entity.EntityState.Deleted;
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