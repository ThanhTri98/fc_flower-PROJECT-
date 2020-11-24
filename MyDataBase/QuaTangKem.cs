namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuaTangKem")]
    public partial class QuaTangKem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuaTangKem()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_qua { get; set; }

        [StringLength(255)]
        public string ten_qua { get; set; }

        [Column(TypeName = "ntext")]
        public string mo_ta { get; set; }

        [StringLength(50)]
        public string ma_loai { get; set; }

        [StringLength(255)]
        public string hinh_anh { get; set; }

        public int? gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual LoaiQuaTang LoaiQuaTang { get; set; }
    }
}
