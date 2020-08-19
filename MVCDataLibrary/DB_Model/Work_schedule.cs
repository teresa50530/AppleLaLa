namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Work_schedule
    {
        [Key]
        public int Schedule_id { get; set; }

        public int Designer_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Session_id { get; set; }

        [StringLength(10)]
        public string Reference_order_detail { get; set; }

        [Required]
        [StringLength(1)]
        public string On_work_flag { get; set; }

        public virtual Designer Designer { get; set; }

        public virtual Session Session { get; set; }
    }
}
