namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Protfolio")]
    public partial class Protfolio
    {
        [Key]
        public int Protfolio_id { get; set; }

        public int? Designer_id { get; set; }

        public int? Service_details_Id { get; set; }

        public string Photo_url { get; set; }

        [StringLength(4)]
        public string Year { get; set; }

        [StringLength(2)]
        public string Month { get; set; }

        [Required]
        [StringLength(7)]
        public string Color_type { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Create_date { get; set; }

        public DateTime Last_updata_date { get; set; }

        public virtual Designer Designer { get; set; }

        public virtual Service_details Service_details { get; set; }
    }
}
