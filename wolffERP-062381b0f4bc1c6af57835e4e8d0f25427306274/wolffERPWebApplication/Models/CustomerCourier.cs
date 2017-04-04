namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This model associates a customer with a courier and indicates whether a courier is the preferred courier
    /// for a particular customer
    /// </summary>

    [Table("CustomerCourier")]
    public partial class CustomerCourier
    {
        [Key]
        [DisplayName("Customer Id")]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal CustomerId { get; set; }

        [Key]
        [DisplayName("Courier Id")]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal CourierId { get; set; }

        [Required]
        [StringLength(1)]
        public string Preferred { get; set; }

        public virtual Courier Courier { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
