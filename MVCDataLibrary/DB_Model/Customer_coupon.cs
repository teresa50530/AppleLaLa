namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer_coupon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cust_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Coupon_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime End_day { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Start_day { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
