namespace Project1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        public SANPHAM()
        {
            SP_HD = new HashSet<SP_HD>();
        }
        [Key]
        [StringLength(50)]
        public string MASP { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public double? Gia { get; set; }

        public int? Soluong { get; set; }

        public string Mota { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        public int MALOAI { get; set; }
        public virtual ICollection<SP_HD> SP_HD { get; set; }
    }
}
