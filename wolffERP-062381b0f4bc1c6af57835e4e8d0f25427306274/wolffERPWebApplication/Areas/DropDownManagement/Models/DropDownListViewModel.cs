using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wolffERPWebApplication.Areas.DropDownManagement.Models
{
    public class DropDownListViewModel
    {
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
        /// This Field is the name of the dropdown list like Brand, Instrument Or Such.
        /// </summary>
        [Required]
        [DisplayName("Dropdown Name")]
        [StringLength(255)]
        public string DropdownName { get; set; }

        /// <summary>
        /// this is the dataType of the value of the drop down list, it could be 
        /// </summary>
        [Required]
        [DisplayName("Dropdown Data Type")]
        [StringLength(255)]
        public string DropdownDataType { get; set; }
    }
}
