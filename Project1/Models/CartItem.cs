using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class CartItem
    {
        public string MASP { get; set; }

        public string Ten { get; set; }

        public double Gia { get; set; }

        public int Soluong { get; set; }
        public double Thanhtien { get { return Gia * Soluong; } }
    }
}