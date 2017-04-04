namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Customer Standard Test model.
    /// This model deals with each of the different types of tests associated with each Customer Standard.
    /// </summary>
    [Table("CustomerStandardTest")]
    public partial class CustomerStandardTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerStandardTest()
        {
            CalibrationTests = new HashSet<CalibrationTest>();
        }

        [Column(TypeName = "numeric")]
        [DisplayName("Customer Standard Test Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CustomerStandardTestId { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Test Percentage")]
        public decimal? TestPercentage { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Customer Standard Id")]
        public decimal CustomerStandardId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalibrationTest> CalibrationTests { get; set; }

        public virtual CustomerStandard CustomerStandard { get; set; }
    }
}
