using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wolffERPWebApplication.Areas.Customers.Models
{
    /// <summary>
    /// This View Model is for the customer creation page, which references the Customer,
    /// Address, and CustomerAddress tables
    /// </summary>
    public class CustomersViewModel
    {
        [Required]
        [DisplayName("Customer Id")]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CustomerId { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression("[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]",
                            ErrorMessage = "Phone number must be in this format: 555-555-5555")]
        [StringLength(12, ErrorMessage = "Phone number must be 12 characters long")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

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