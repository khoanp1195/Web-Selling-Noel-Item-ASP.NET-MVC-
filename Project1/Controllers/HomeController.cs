using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Model1 db = new Model1();
            List<SANPHAM> sanphams = db.SANPHAMs.ToList();
            return View(sanphams);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult LoadCategory()
        {

            Model1 db = new Model1();
            List<LOAI_SP> listcat = db.LOAI_SP.ToList();
            return PartialView(listcat);
        }
      
        public ActionResult loadlistdanhmuc(int id_loaisanpham)
        {

            Model1 db = new Model1();
            List<SANPHAM> danhmucsanpham = (from d in db.SANPHAMs where d.MALOAI==id_loaisanpham select d).ToList();
            return View(danhmucsanpham);

        }
        

    }
}