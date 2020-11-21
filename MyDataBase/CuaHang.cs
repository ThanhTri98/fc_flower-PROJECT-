namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuaHang")]
    public partial class CuaHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_cua_hang { get; set; }

        [StringLength(255)]
        public string ten_cua_hang { get; set; }

        [StringLength(255)]
        public string dia_chi { get; set; }

        [StringLength(255)]
        public string gioi_thieu { get; set; }

        [StringLength(20)]
        public string so_dien_thoai { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(255)]
        public string quan_ly { get; set; }
    }
}
