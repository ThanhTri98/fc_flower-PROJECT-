namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiQuaTang")]
    public partial class LoaiQuaTang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiQuaTang()
        {
            QuaTangKem = new HashSet<QuaTangKem>();
        }

        [Key]
        [StringLength(50)]
        public string ma_loai { get; set; }

        [StringLength(255)]
        public string ten_loai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuaTangKem> QuaTangKem { get; set; }
    }
}
