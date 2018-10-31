using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
namespace ThunderDuckGroup.Controllers
{
    public class HomeController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        public ActionResult Index()
        {
            List<HomeMaster> lst = new List<HomeMaster>();
            HomeMaster home = new HomeMaster();
            var contact = db.Td_BrandMaker_Contact.Where(st => st.id == 1);
            home.con = contact;
           
            
            lst.Add(home);
            return View(lst);
        }
    }
}