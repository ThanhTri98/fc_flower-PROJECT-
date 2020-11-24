namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiHoa")]
    public partial class LoaiHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiHoa()
        {
            Hoa = new HashSet<Hoa>();
        }

        [Key]
        [StringLength(50)]
        public string ma_loai_hoa { get; set; }

        [Required]
        [StringLength(255)]
        public string ten_loai_hoa { get; set; }

        public int ma_y_nghia { get; set; }

        [StringLength(255)]
        public string hinh_anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoa> Hoa { get; set; }

        public virtual YNghiaHoa YNghiaHoa { get; set; }
    }
}
