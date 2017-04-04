namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Vendor Address model.
    /// The Vendor Address model provides more details about where the vendor is located.
    /// </summary>
    [Table("VendorAddress")]
    public partial class VendorAddress
    {
        /// <summary>
        /// Vendor ID is a primary key
        /// Vendor ID is a unique identifier used to look up the vendor id information in the database.
        /// </summary>
        [Key]
        [Required]
        [DisplayName("Vendor ID")]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal VendorId { get; set; }

        /// <summary>
        /// Vendor ID is a primary key
        /// Address ID is a unique identifier used to look up the address id information in the database.
        /// </summary>
        [Key]
        [Required]
        [DisplayName("Address ID")]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal AddressId { get; set; }

        /// <summary>
        /// Address Type is a unique identifier used to look up the address type information in the database.
        /// Address Type needs to be entered for web page to continue
        /// </summary>
        [Required]
        [DisplayName("Address Type")]
        [StringLength(1)]
        public string AddressType { get; set; }

        public virtual Address Address { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
