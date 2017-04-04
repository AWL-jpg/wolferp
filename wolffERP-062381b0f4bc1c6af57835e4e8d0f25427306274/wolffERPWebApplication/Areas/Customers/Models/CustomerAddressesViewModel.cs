using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wolffERPWebApplication.Areas.Customers.Models
{
    public class CustomerAddressesViewModel
    {
        [Required]
        [DisplayName("Customer Id")]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CustomerId { get; set; }

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

        [Required]
        [DisplayName("Address Type")]
        [StringLength(1)]
        public string AddressType { get; set; }
    }
}