using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        Model1 db = new Model1();
        public ActionResult Index()
        {
            var cart = Session["cart"];
            var listItem = new List<CartItem>();
            if (cart != null)
            {
                listItem = (List<CartItem>)cart;
            }
            return View(listItem);
        }
        public ActionResult Add(string Id, int soluong, string name, double gia)
        {
            //Init cart session
            var cart = Session["cart"];
            if (cart != null)
            {
                var listItem = (List<CartItem>)cart;
                if (listItem.Exists(x => x.MASP == Id))
                {
                    foreach (var item in listItem)
                    {
                        if (item.MASP == Id)
                        {
                            item.Soluong += soluong;
                        }

                    }
                }
                else
                {
                    var item = new CartItem();
                    item.MASP = Id;
                    item.Soluong = soluong;
                    item.Gia = gia;
                    item.Ten = name;
                    listItem.Add(item);

                }
                Session["cart"] = listItem;
            }
            else
            {
                var item = new CartItem();
                item.MASP = Id;
                item.Soluong = soluong;
                item.Ten = name;
                item.Gia = gia;
                var listItem = new List<CartItem>();
                listItem.Add(item);
                Session["cart"] = listItem;
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(string ID)
        {
            List<CartItem> cart = Session["cart"] as List<CartItem>;
            CartItem deletecart = cart.FirstOrDefault(x => x.MASP == ID);
            if (deletecart != null)
            {
                cart.Remove(deletecart);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(string Id, int soluong)
        {
            List<CartItem> cart = Session["cart"] as List<CartItem>;
            CartItem UpdateCart = cart.FirstOrDefault(x => x.MASP == Id);
            if (UpdateCart != null)
            {
                UpdateCart.Soluong = soluong;
            }
            return RedirectToAction("Index");
        }
        public ActionResult ThanhToan()
        {
            var cart = Session["cart"];
            var listItem = new List<CartItem>();
            if (cart != null)
            {
                listItem = (List<CartItem>)cart;
            }
            return View(listItem);
        }
        public ActionResult CheckOut(FormCollection form)
        {
            double total = 0;
            List<CartItem> listcart = Session["cart"] as List<CartItem>;
            foreach (CartItem cart in listcart)
            {
                total += cart.Soluong * cart.Gia;
            }
            HOADON bill = new HOADON()
            {
                TenKH = form["customerName"],
                DiachiKH = form["diachi"],
                Ngaytao = DateTime.Now,
                Trangthai = 0,
                Tongtien = total
            };
            db.HOADONs.Add(bill);
            db.SaveChanges();
            foreach (CartItem cart in listcart)
            {
                SP_HD billDetail = new SP_HD()
                {
                    MAHD = bill.MAHD,
                    MASP = cart.MASP,
                    Soluong = cart.Soluong,
                    Gia = cart.Gia,

                };
                db.SP_HD.Add(billDetail);
                db.SaveChanges();
            }
            Session.Remove("cart");
            return View(bill);
        }
    }
}