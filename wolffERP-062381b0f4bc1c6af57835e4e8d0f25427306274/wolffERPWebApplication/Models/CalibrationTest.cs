namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This model contains the error value (UpscaleError) entered by the user for a specific row 
    /// in a test table (TestField) for a specific item's calibration test
    /// </summary>

    [Table("CalibrationTest")]
    public partial class CalibrationTest
    {
        [Required]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CalibrationTestId { get; set; }

        [Required]
        [DisplayName("Error")]
        [Column(TypeName = "numeric")]
        public decimal? UpscaleError { get; set; }

        [Required]
        [DisplayName("Test Field")]
        [Column(TypeName = "numeric")]
        public decimal? TestField { get; set; }

        [Required]
        [DisplayName("Customer Standard Test Id")]
        [Column(TypeName = "numeric")]
        public decimal? CustomerStandardTestId { get; set; }

        [Required]
        [DisplayName("Service Certificate Id")]
        [Column(TypeName = "numeric")]
        public decimal? ServiceCertificateId { get; set; }

        public virtual CustomerStandardTest CustomerStandardTest { get; set; }

        public virtual ServiceCertificate ServiceCertificate { get; set; }
    }
}
