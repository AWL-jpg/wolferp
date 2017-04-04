namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Dropdown Type model.
    /// The Dropdown Type model deals with the different categories of dropdown lists that are available.
    /// </summary>
    [Table("DropdownType")]
    public partial class DropdownType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DropdownType()
        {
            DropdownItems = new HashSet<DropdownItem>();
        }

        [Column(TypeName = "numeric")]
        [DisplayName("Dropdown Type Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal DropdownTypeId { get; set; }

        [Required]
        [DisplayName("Dropdown Name")]
        [StringLength(255)]
        public string DropdownName { get; set; }

        [Required]
        [DisplayName("Dropdown Data Type")]
        [StringLength(255)]
        public string DropdownDataType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DropdownItem> DropdownItems { get; set; }
    }
}
