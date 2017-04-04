namespace wolffERPWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DropdownItemDetail")]
    public partial class DropdownItemDetail
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal ServiceOrderItemId { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal DropdownItemId { get; set; }
    }
}
