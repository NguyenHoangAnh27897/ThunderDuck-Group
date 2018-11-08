using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
namespace ThunderDuckGroup.Controllers.Webmaster.ConstructionWebmaster
{
    public class WebmasterConstructionController : Controller
    {
		ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: WebmasterConstruction
        public ActionResult Index()
        {
            if (Session["Authentication"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
			if (Username.Equals("admin"))
			{
				var rs = db.Td_Construction_Account.Find(1);
				if (rs.Password.Equals(Password))
				{
					Session["Authentication"] = true;
					return RedirectToAction("Index");
				}
				//return RedirectToAction("Index");
				else
				{
					return RedirectToAction("Login", "WebmasterConstruction");
				}
			}
			else
			{
				return RedirectToAction("Login", "WebmasterConstruction");
			}
		}

		[HttpPost]
        public ActionResult Logout()
        {
            if (Session["Authentication"] != null)
            {
                return RedirectToAction("null");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}