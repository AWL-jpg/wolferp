namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Service Certificate model.
    /// The Service Certificate provides more details about the service performed on a specific item.
    /// </summary>
    [Table("ServiceCertificate")]
    public partial class ServiceCertificate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCertificate()
        {
            CalibrationTests = new HashSet<CalibrationTest>();
            ServiceOrderItems = new HashSet<ServiceOrderItem>();
        }

        [Column(TypeName = "numeric")]
        [DisplayName("Service Certificate Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ServiceCertificateId { get; set; }

        [DisplayName("Calibration Certificate Number")]
        [Column(TypeName = "numeric")]
        public decimal? CalibrationCertificateNumber { get; set; }

        public DateTime? Date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Humidity { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Ambient Temperature")]
        public decimal? AmbientTemperature { get; set; }

        [DisplayName("Deadweight Certificate")]
        public byte[] DWTCertificate { get; set; }

        [DisplayName("Maximum Error")]
        [Column(TypeName = "numeric")]
        public decimal? MaximumError { get; set; }

        [DisplayName("Display Name Accuracy")]
        [Column(TypeName = "numeric")]
        public decimal? TestGaugeAccuracy { get; set; }

        [DisplayName("Test Medium")]
        [StringLength(255)]
        public string TestMedium { get; set; }

        [StringLength(255)]
        public string Invoice { get; set; }

        [DisplayName("Technician Id")]
        [Column(TypeName = "numeric")]
        public decimal? TechnicianId { get; set; }

        [DisplayName("QC Technician Id")]
        [Column(TypeName = "numeric")]
        public decimal? QCTechnicianId { get; set; }

        [DisplayName("Deadweight Serial Number Id")]
        [Column(TypeName = "numeric")]
        public decimal? DeadweightSNId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalibrationTest> CalibrationTests { get; set; }

        public virtual DeadweightSN DeadweightSN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; set; }
    }
}
