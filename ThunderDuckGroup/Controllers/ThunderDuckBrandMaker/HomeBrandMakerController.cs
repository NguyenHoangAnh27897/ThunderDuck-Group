using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThunderDuckGroup.Models;
namespace ThunderDuckGroup.Controllers.ThunderDuckBrandMaker
{
    public class HomeBrandMakerController : Controller
    {
        ThunderDuckEntities3 db = new ThunderDuckEntities3();
        // GET: HomeBrandMaker
        public ActionResult IndexBrandMaker()
        {
            List<HomeMaster> lst = new List<HomeMaster>();
            HomeMaster home = new HomeMaster();
            var story = db.Td_BrandMaker_Story.Where(st => st.id == 1);
            var tour = db.Td_BrandMaker_Tours.ToList();
            var events = db.Td_BrandMaker_Events.ToList();
            var type = db.Td_BrandMaker_AreaType.ToList();
            var image = db.Td_BrandMaker_Images.ToList();
            var newss = db.Td_BrandMaker_News.ToList();
            var contact = db.Td_BrandMaker_Contact.Where(st => st.id == 1);
            var slide = db.Td_BrandMaker_Slider.Where(st => st.id == 1);
            var mems = db.Td_BrandMaker_Members.ToList();
            home.sto = story;
            home.tou = tour;
            home.eve = events;
            home.evetype = type;
            home.img = image;
            home.newss = newss;
            home.con = contact;
            home.sli = slide;
            home.mem = mems;
            lst.Add(home);
            return View(lst);
        }

        public ActionResult TourDetail(int id)
        {
            var ls = db.Td_BrandMaker_Tours.Find(id);
            return View(ls);
        }

        public ActionResult ProfileDetail (int id)
        {
            var ls = db.Td_BrandMaker_Members.Find(id);
            return View(ls);
        }

        public ActionResult EventDetail (int id)
        {
            var ls = db.Td_BrandMaker_Events.Find(id);
            return View(ls);
        }

        public ActionResult NewDetail(int id)
        {
            var ls = db.Td_BrandMaker_News.Find(id);
            return View(ls);
        }
    }
}