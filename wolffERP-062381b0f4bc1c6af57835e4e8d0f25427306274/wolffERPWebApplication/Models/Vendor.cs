namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Vendor model.
    /// The Vendor model provides more details about the vendor.
    /// </summary>
    [Table("Vendor")]
    public partial class Vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendor()
        {
            ServiceOrders = new HashSet<ServiceOrder>();
            VendorAddresses = new HashSet<VendorAddress>();
        }

        /// <summary>
        /// Vendor ID is a primary key
        /// Vendor ID is a unique identifier used to look up the vendor id information in the database.
        /// </summary>
        [Required]
        [Column(TypeName = "numeric")]
        [DisplayName("Vendor ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal VendorId { get; set; }

        /// <summary>
        /// Name refers to the name of the vendor in the system
        /// </summary>
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Email refers to the email of the vendor in the system
        /// </summary>
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// Phone number refers to the phone number of the vendor in the system
        /// </summary>
        [DisplayName("Phone Number")]
        [RegularExpression("[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]",
                            ErrorMessage = "Phone number must be in this format: 555-555-5555")]
        [StringLength(12, ErrorMessage = "Phone number must be 12 characters long")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Notes referes to notes about the vendor in the system.
        /// </summary>
        [StringLength(255)]
        public string Notes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorAddress> VendorAddresses { get; set; }
    }
}
