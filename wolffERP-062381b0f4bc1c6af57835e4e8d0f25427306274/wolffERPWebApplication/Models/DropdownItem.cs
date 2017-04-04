namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the Dropdown Item Model.
    /// The Dropdown Item model deals with all the items that are being entered into a dropdown list in this system.
    /// This model gives the Dropdown Item an DropdownItemId, DropdownValue, Hidden, DropdownTypeId and DropdownType values.
    /// </summary>
    [Table("DropdownItem")]
    public partial class DropdownItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DropdownItem()
        {
            ServiceOrderItems = new HashSet<ServiceOrderItem>();
        }

        [Column(TypeName = "numeric")]
        [DisplayName("Dropdown Item Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal DropdownItemId { get; set; }

        [Required]
        [DisplayName("Dropdown Value")]
        [StringLength(255)]
        public string DropdownValue { get; set; }

        /// <summary>
        /// The Hidden field declares whether an item will be displayed or not in the dropdown list or table.
        /// </summary>
        [Required]
        [StringLength(1)]
        public string Hidden { get; set; }

        /// <summary>
        /// The DropdownTypeId field assigns the DropdownItem to a specific dropdown category.
        /// </summary>
        [Column(TypeName = "numeric")]
        [DisplayName("Dropdown Type Id")]
        public decimal DropdownTypeId { get; set; }

        /// <summary>
        /// The DropdownType field displays the name of the dropdown category based on the Id selected.
        /// </summary>
        [DisplayName("Dropdown Type")]
        public virtual DropdownType DropdownType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; set; }
    }
}
