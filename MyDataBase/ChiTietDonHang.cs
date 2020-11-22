namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_dh { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_hoa { get; set; }

        public int ma_qua { get; set; }

        public byte? so_luong { get; set; }

        public int? tong_gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual Hoa Hoa { get; set; }

        public virtual QuaTangKem QuaTangKem { get; set; }
    }
}
