namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This model contains a specific set of address information for a given customer. 
    /// Customers can have multiple addresses.
    /// </summary>

    [Table("Address")]
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Contacts = new HashSet<Contact>();
            CustomerAddresses = new HashSet<CustomerAddress>();
            VendorAddresses = new HashSet<VendorAddress>();
        }

        [Required]
        [DisplayName("Address Id")]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal AddressId { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        [StringLength(255)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(2)]
        public string Province { get; set; }

        [Required]
        [DisplayName("Street Address 1")]
        [StringLength(255)]
        public string Street1 { get; set; }

        [StringLength(255)]
        [DisplayName("Street Address 2")]
        public string Street2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorAddress> VendorAddresses { get; set; }
    }
}
