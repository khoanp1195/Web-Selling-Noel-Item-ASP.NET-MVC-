using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Chitiet(string id)
        {
            Model1 db = new Model1();
            SANPHAM sanphams = db.SANPHAMs.FirstOrDefault(x => x.MASP == id);
            return View(sanphams);
        }
    }
    
}