using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wolffERPWebApplication.Areas.LogBook.Models
{
    /// <summary>
    /// A view model to hold information on LogBook listings.
    /// </summary>
    public class LogBookItem
    {
        /// <summary>
        /// The database identifier for service order items.
        /// </summary>
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ServiceOrderitemId { get; set; }

        /// <summary>
        /// The serial number stamped on the gauge.
        /// </summary>
        [DisplayName("Serial Number")]
        [StringLength(255)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// A non-database identifier for Jaron Wolff service orders.
        /// </summary>
        [DisplayName("Invoice Number")]
        [Column(TypeName = "numeric")]
        public decimal ServiceOrderNumber { get; set; }

        /// <summary>
        /// The number belonging to the gauge's deadweight certificate. May be null.
        /// </summary>
        [DisplayName("Calibration Certificate Number")]
        [Column(TypeName = "numeric")]
        public decimal? CalibrationCertificateNumber { get; set; }

        /// <summary>
        /// The number belonging to the gauge's oxygen certificate. May be null.
        /// </summary>
        [DisplayName("O2 Certificate Number")]
        [Column(TypeName = "numeric")]
        public decimal? OxygenCertificateNumber { get; set; }

        /// <summary>
        /// The name of the customer who requested service on this gauge.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// The date on which this service order was completed.
        /// </summary>
        public DateTime? Date { get; set; }
    }
}