namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This model contains all relevant information about a contact for a particular address associated with a customer.
    /// Adresses can have multiple contacts. 
    /// </summary>

    [Table("Contact")]
    public partial class Contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {
            ServiceOrders = new HashSet<ServiceOrder>();
        }

        [Required]
        [DisplayName("Contact Id")]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ContactId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression("[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]",
                            ErrorMessage = "Phone number must be in this format: 555-555-5555")]
        [StringLength(12, ErrorMessage ="Phone number must be 12 characters long")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [DisplayName("Address Id")]
        [Column(TypeName = "numeric")]
        public decimal? AddressId { get; set; }

        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }
    }
}
