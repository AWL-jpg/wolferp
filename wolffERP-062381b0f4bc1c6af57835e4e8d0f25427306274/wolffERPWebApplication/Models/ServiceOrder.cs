namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Service Order Model.
    /// The Service Order model contains information about the Service Order supplied for a specific order.
    /// </summary>
    [Table("ServiceOrder")]
    public partial class ServiceOrder
    {
        /// <summary>
        /// A classless constructor for this model. Fetches or instantiates a list of service order items.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceOrder()
        {
            ServiceOrderItems = new HashSet<ServiceOrderItem>();
        }

        /// <summary>
        /// Service Order ID uniquely identifies a service order in the system. 
        /// </summary>
        [Required]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ServiceOrderId { get; set; }

        /// <summary>
        /// Service Order Number is the non-database identifier for a service order.
        /// </summary>
        [Required]
        [Column(TypeName = "numeric")]
        public decimal ServiceOrderNumber { get; set; }

        /// <summary>
        /// Service Type is the type of service being preformed on the item.
        /// </summary>
        [DisplayName("Service Type")]
        [StringLength(255)]
        public string ServiceType { get; set; }

        /// <summary>
        /// Date when the service order has been recieved.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Status of the service order
        /// </summary>
        [StringLength(255)]
        public string Status { get; set; }

        /// <summary>
        /// Notes on the service order.
        /// </summary>
        [Column(TypeName = "text")]
        public string Notes { get; set; }

        /// <summary>
        /// Rushed refers to a service order having to be done quickly or not
        /// </summary>
        [Required]
        [StringLength(1)]
        public string Rushed { get; set; }

        /// <summary>
        /// Purchase Order Number refers to the purchase order number of the item.
        /// </summary>
        
        [DisplayName("Purchase Order Number")]
        [StringLength(255)]
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Sublet PO number refers to the po number of the service order if it is sent off base.
        /// </summary>
        [DisplayName("Sublet PO Number")]
        [StringLength(255)]
        public string SubletPONumber { get; set; }

        /// <summary>
        /// Courier id refers to the courier transporting the product.
        /// </summary>
        [DisplayName("Courier ID")]
        [Column(TypeName = "numeric")]
        public decimal? CourierId { get; set; }

        /// <summary>
        /// Customer id is a unique identifier for the customer listed on the service order
        /// </summary>
        [DisplayName("Customer ID")]
        [Column(TypeName = "numeric")]
        public decimal? CustomerId { get; set; }

        /// <summary>
        /// Contact id is a unique identifier for the contact listed on the service order
        /// </summary>
        [DisplayName("Contact ID")]
        [Column(TypeName = "numeric")]
        public decimal? ContactId { get; set; }

        /// <summary>
        /// Vendor id is a unique identifier for the vendor listed on the service order
        /// </summary>
        [DisplayName("Vendor ID")]
        [Column(TypeName = "numeric")]
        public decimal? VendorId { get; set; }

        /// <summary>
        /// Navigation to the Contact attached to the service order.
        /// </summary>
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// Navigation to the Courier attached to the service order.
        /// </summary>
        public virtual Courier Courier { get; set; }

        /// <summary>
        /// Navigation to the Customer attached to the service order.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Navigation to the Vendor attached to the service order.
        /// </summary>
        public virtual Vendor Vendor { get; set; }
        
        /// <summary>
        /// Navigation to a list of the ServiceOrderItems attached to the service order.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; set; }

    }
}
