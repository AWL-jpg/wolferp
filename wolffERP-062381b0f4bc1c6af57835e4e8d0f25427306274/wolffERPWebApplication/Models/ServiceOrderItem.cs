namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Service Order Item model.
    /// The Service Order Item provides more details about an item on a specific service order.
    /// </summary>
    [Table("ServiceOrderItem")]
    public partial class ServiceOrderItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceOrderItem()
        {
            DropdownItems = new HashSet<DropdownItem>();
        }

        /// <summary>
        /// Service Order Item ID is a unique identifier given to each service order item
        /// </summary>
        [Required]
        [Column(TypeName = "numeric")]
        [DisplayName("Service Order Item ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ServiceOrderitemId { get; set; }

        /// <summary>
        /// Serial Number refers to the serial number of a service order item
        /// </summary>
        [DisplayName("Serial Number")]
        [StringLength(255)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Service refers to the type of service being done on an item
        /// </summary>
        [StringLength(255)]
        public string Service { get; set; }

        /// <summary>
        /// Fittings refers to the fittings used on that item.
        /// </summary>
        [StringLength(1)]
        public string Fittings { get; set; }

        /// <summary>
        /// Notes about the service order item
        /// </summary>
        [Column(TypeName = "text")]
        public string Notes { get; set; }

        /// <summary>
        /// Hidden refers to if a item is taken off the order or isn't.
        /// </summary>
        [Required]
        [StringLength(1)]
        public string Hidden { get; set; }

        /// <summary>
        /// Customer Standard ID uniquely identifies a customer standard.
        /// </summary>
        [Column(TypeName = "numeric")]
        [DisplayName("Customer Standard ID")]
        public decimal? CustomerStandardId { get; set; }

        /// <summary>
        /// Service Order ID uniquely identifies a service order in the system.
        /// </summary>
        [Required]
        [Column(TypeName = "numeric")]
        public decimal ServiceOrderId { get; set; }

        /// <summary>
        /// Oxygen Certificate ID uniquely identifies a oxygen certificate in the system,
        /// </summary>
        [Column(TypeName = "numeric")]
        [DisplayName("Oxygen Certificate ID")]
        public decimal? OxygenCertificateId { get; set; }

        /// <summary>
        /// Service Certificate ID uniquely identifies the service certificate in the system.
        /// </summary>
        [Column(TypeName = "numeric")]
        [DisplayName("Service Certificate ID")]
        public decimal? ServiceCertificateId { get; set; }

        [DisplayName("Customer Standard")]
        public virtual CustomerStandard CustomerStandard { get; set; }

        [DisplayName("Oxygen Certificate")]
        public virtual OxygenCertificate OxygenCertificate { get; set; }

        [DisplayName("Service Certificate")]
        public virtual ServiceCertificate ServiceCertificate { get; set; }

        [DisplayName("Service Order")]
        public virtual ServiceOrder ServiceOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DropdownItem> DropdownItems { get; set; }
    }
}
