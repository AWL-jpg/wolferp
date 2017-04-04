namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Deadweight Serial Number Model.
    /// This model will deals with the Serial Number and Hidden status for each Deadweight.
    /// </summary>
    [Table("DeadweightSN")]
    public partial class DeadweightSN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeadweightSN()
        {
            ServiceCertificates = new HashSet<ServiceCertificate>();
        }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal DeadweightSNId { get; set; }

        [Required]
        [DisplayName("Serial Number")]
        [StringLength(255)]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(1)]
        public string Hidden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCertificate> ServiceCertificates { get; set; }
    }
}
