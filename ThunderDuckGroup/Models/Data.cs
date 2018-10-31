using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThunderDuckGroup.Models;

namespace ThunderDuckGroup.Models
{
    public class HomeMaster
    {
        public IQueryable<Td_BrandMaker_Story> sto { get; set; }
        public IQueryable<Td_BrandMaker_Slider> sli { get; set; }
        public List<Td_BrandMaker_Tours> tou { get; set; }
        public List<Td_BrandMaker_Events> eve { get; set; }
        public List<Td_BrandMaker_News> newss { get; set; }
        public List<Td_BrandMaker_Images> img { get; set; }
        public List<Td_BrandMaker_Members> mem { get; set; }
        public IQueryable<Td_BrandMaker_Contact> con { get; set; }
        public List<Td_BrandMaker_AreaType> evetype { get; set; }
    }

    public class Event
    {
        public List<Td_BrandMaker_AreaType> area { get; set; }
        public IQueryable<Td_BrandMaker_Events> events { get; set; }
    }

    public class Member
    {
        public IQueryable<Td_BrandMaker_Members> memem { get; set; }
    }


    public class Tour
    {
        public IQueryable<Td_BrandMaker_Tours> tours { get; set; }
    }

    public class News
    {
        public IQueryable<Td_BrandMaker_News> newsss { get; set; }
    }

    public class Images
    {
        public IQueryable<Td_BrandMaker_Images> image { get; set; }
    }


    public class ConMaster
    {
        public IQueryable<Td_Constrution_Story> stor { get; set; }
        public IQueryable<Td_Construction_Slider> slie { get; set; }
        public List<Td_Construction_Construction> constr { get; set; }
        public IQueryable<Td_Construction_Contact> conta { get; set; }
        public List<Td_Construction_Images> ima { get; set; }
        public List<Td_Construction_Member> meme { get; set; }
        public List<Td_Construction_New> news { get; set; }
    }
}
