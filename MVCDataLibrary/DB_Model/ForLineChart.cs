namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ForLineChart")]
    public partial class ForLineChart
    {
        [Key]
        public string Name { get; set; }

        [StringLength(30)]
        public string OrderDate { get; set; }

        public int? Nday { get; set; }

        public decimal? Total { get; set; }
    }
}
