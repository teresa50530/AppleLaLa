namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_details
    {
        [Key]
        [StringLength(10)]
        public string Order_detail_no { get; set; }

        [Required]
        [StringLength(16)]
        public string Order_id { get; set; }

        public int Service_details_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Appointment_date { get; set; }

        public int Session_id { get; set; }

        public int Designer_id { get; set; }

        public int? Coupon_id { get; set; }

        public DateTime Last_updata_date { get; set; }

        public virtual Order Order { get; set; }

        public virtual Service_details Service_details { get; set; }
    }
}
