using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
namespace ThunderDuckGroup.Controllers.Webmaster.BrandMakerWebmaster
{
    public class AccountBrandMakerController : Controller
    {
		ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: AccountMaster
        public ActionResult Edit()
        {
			if (Session["Authentication"] != null)
			{
				var home = db.Td_BrandMaker_Account.Where(st => st.id == 1);
				return View();
			}
			else
			{
				return RedirectToAction("Login", "WebmasterBrandMaker");
			}
        }

		[HttpPost]
		public ActionResult Edit(string oldpassword, string newpassword, string confirmpassword)
		{
			if(Session["Authentication"] != null)
			{
				var lst = db.Td_BrandMaker_Account.Find(1);
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
				return RedirectToAction("Login", "WebmasterBrandMaker");
			}
		}
    }
}