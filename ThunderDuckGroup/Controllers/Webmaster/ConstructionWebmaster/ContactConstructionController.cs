using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;

namespace ThunderDuckGroup.Controllers.Webmaster.ConstructionWebmaster
{
    public class ContactConstructionController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: ContactConstruction
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var home = db.Td_Construction_Contact.Where(st => st.id == 1);
                return View(home);
            }
            else
            {
                return RedirectToAction("Login", "Webmasterconstruction");
            }
        }

        [HttpPost]
        public ActionResult Edit(string email, string email1, string email2, string phone, string phone1, string hot, string head, string office)
        {
            if (Session["Authentication"] != null)
            {
                var home = db.Td_Construction_Contact.Find(1);
                home.Email = email;
                home.Email1 = email1;
                home.Email2 = email2;
                home.Phone = phone;
                home.Phone1 = phone1;
                home.Hotline = hot;
                home.HeadAddress = head;
                home.OfficeAddress = office;
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