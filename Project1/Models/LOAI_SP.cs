namespace Project1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOAI_SP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALOAI { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }
    }
}
