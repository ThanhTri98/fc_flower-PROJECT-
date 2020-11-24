using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDataBase
{
    [Table("ChuDe")]
    public partial class ChuDe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuDe()
        {
            Hoa = new HashSet<Hoa>();
        }

        [Key]
        [StringLength(255)]
        public string ma_chu_de { get; set; }

        [StringLength(255)]
        public string ten_chu_de { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoa> Hoa { get; set; }
    }
}
