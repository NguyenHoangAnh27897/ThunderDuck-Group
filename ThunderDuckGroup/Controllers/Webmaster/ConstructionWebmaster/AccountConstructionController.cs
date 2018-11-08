using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
namespace ThunderDuckGroup.Controllers.Webmaster.ConstructionWebmaster
{
    public class AccountConstructionController : Controller
    {
		ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: AccountConstruction
        public ActionResult Edit()
        {
			if (Session["Authentication"] != null)
			{
				var home = db.Td_Construction_Account.Where(st => st.id == 1);
				return View();
			}
			else
			{
				return RedirectToAction("Login", "WebmasterConstruction");
			}

		}

		[HttpPost]
		public ActionResult Edit(string oldpassword, string newpassword, string confirmpassword)
		{
			if (Session["Authentication"] != null)
			{
				var lst = db.Td_Construction_Account.Find(1);
				if (lst.Password.Equals(oldpassword))
				{
					if (newpassword == confirmpassword)
					{
						lst.Password = newpassword;
						db.Entry(lst).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
					}
				}
				return RedirectToAction("Edit");
			}
			else
			{
				return RedirectToAction("Login", "WebmasterConstruction");
			}
		}
	}
}