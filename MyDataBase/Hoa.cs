namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoa")]
    public partial class Hoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoa()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            ChuDe = new HashSet<ChuDe>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_hoa { get; set; }

        [StringLength(255)]
        public string tieu_de { get; set; }

        public int? gia_cu { get; set; }

        public int? gia_moi { get; set; }

        [StringLength(255)]
        public string hinh_anh { get; set; }

        [Column(TypeName = "ntext")]
        public string mo_ta { get; set; }

        [StringLength(50)]
        public string ma_loai_hoa { get; set; }

        [StringLength(50)]
        public string ma_mau_sac { get; set; }

        public int? ma_tth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual LoaiHoa LoaiHoa { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual TinhTrangHoa TinhTrangHoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuDe> ChuDe { get; set; }
    }
}
