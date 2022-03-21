namespace Project1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        public int MAHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngaytao { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKH { get; set; }

        public double Tongtien { get; set; }

        public int Trangthai { get; set; }

        [Required]
        [StringLength(50)]
        public string DiachiKH { get; set; }
    }
}
