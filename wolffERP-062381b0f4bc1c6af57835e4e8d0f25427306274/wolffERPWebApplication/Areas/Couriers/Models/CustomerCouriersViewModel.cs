using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wolffERPWebApplication.Areas.Couriers.Models
{
    public class CustomerCouriersViewModel
    {
        [Required]
        [DisplayName("Courier Id")]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CourierId { get; set; }

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

        [Required]
        [DisplayName("Preferred")]
        [StringLength(1)]
        public string Preferred { get; set; }
    }
}