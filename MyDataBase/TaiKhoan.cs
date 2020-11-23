namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(255)]
        public string tai_khoan { get; set; }
        [StringLength(255)]
        public string ho_ten { get; set; }
        [StringLength(255)]
        public string mat_khau { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string so_dien_thoai { get; set; }

        [StringLength(255)]
        public string dia_chi { get; set; }

        [StringLength(255)]
        public string gioi_tinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
