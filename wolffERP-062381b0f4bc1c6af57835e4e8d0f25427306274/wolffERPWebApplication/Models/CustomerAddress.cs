namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This model associates a customer with an address, and the AddressType field specifies whether the address 
    /// is a shipping or billing address.
    /// </summary>

    [Table("CustomerAddress")]
    public partial class CustomerAddress
    {
        [Key]
        [DisplayName("Customer Id")]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CustomerId { get; set; }

        [Key]
        [DisplayName("Address Id")]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal AddressId { get; set; }

        [Required]
        [DisplayName("Address Type")]
        [StringLength(1)]
        public string AddressType { get; set; }

        public virtual Address Address { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
