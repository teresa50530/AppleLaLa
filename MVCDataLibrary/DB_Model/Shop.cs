namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shop")]
    public partial class Shop
    {
        [Key]
        public int Shop_id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [Required]
        [StringLength(25)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        [StringLength(20)]
        public string Line_Id { get; set; }
    }
}
