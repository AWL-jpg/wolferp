namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Oxygen Certificate Model.
    /// The Oxygen Certificate model contains information about the Oxygen Certificate supplied for a specific item.
    /// </summary>
    [Table("OxygenCertificate")]
    public partial class OxygenCertificate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OxygenCertificate()
        {
            ServiceOrderItems = new HashSet<ServiceOrderItem>();
        }

        [Column(TypeName = "numeric")]
        [DisplayName("Oxygen Certificate Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal OxygenCertificateId { get; set; }

        [DisplayName("O2 Certificate Number")]
        [Column(TypeName = "numeric")]
        public decimal? OxygenCertificateNumber { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; set; }
    }
}
