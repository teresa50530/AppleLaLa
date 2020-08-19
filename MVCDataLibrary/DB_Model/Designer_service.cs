namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Designer_service
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Designer_id { get; set; }

        public int? Service_details_Id { get; set; }

        public int? Service_type_id { get; set; }

        public int? Service_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Last_updata_date { get; set; }

        public virtual Designer Designer { get; set; }

        public virtual Service Service { get; set; }

        public virtual Service_details Service_details { get; set; }

        public virtual Service_types Service_types { get; set; }
    }
}
