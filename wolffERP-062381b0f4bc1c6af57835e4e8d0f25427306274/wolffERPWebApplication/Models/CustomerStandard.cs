namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Customer Standard Model.
    /// This model deals with all the different testpoints that each customer standard will have.
    /// </summary>
    [Table("CustomerStandard")]
    public partial class CustomerStandard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerStandard()
        {
            CustomerStandardTests = new HashSet<CustomerStandardTest>();
            ServiceOrderItems = new HashSet<ServiceOrderItem>();
        }

        [Column(TypeName = "numeric")]
        [DisplayName("Customer Standard Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CustomerStandardId { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Customer Standard Number")]
        public string CustomerStandardNumber { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Test Fields")]
        public decimal TestFields { get; set; }

        [Required]
        [StringLength(1)]
        public string Hidden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerStandardTest> CustomerStandardTests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; set; }
    }
}
