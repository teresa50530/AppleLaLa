namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        [Key]
        [Column("Banner")]
        public int Banner1 { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        [StringLength(30)]
        public string Sut_title { get; set; }

        public string Text { get; set; }

        public string Banner_photo_url { get; set; }

        public DateTime Last_updata_date { get; set; }
    }
}
