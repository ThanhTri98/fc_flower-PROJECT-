namespace MyDataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YNghiaHoa")]
    public partial class YNghiaHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YNghiaHoa()
        {
            LoaiHoa = new HashSet<LoaiHoa>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_y_nghia { get; set; }

        [Column(TypeName = "ntext")]
        public string mo_ta { get; set; }

        [Column(TypeName = "ntext")]
        public string chi_tiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiHoa> LoaiHoa { get; set; }
    }
}
