namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service_details()
        {
            Order_details = new HashSet<Order_details>();
            Protfolio = new HashSet<Protfolio>();
            Designer_service = new HashSet<Designer_service>();
        }

        public int Type_id { get; set; }

        [Key]
        public int Service_details_Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short Work_duration { get; set; }

        public decimal Price { get; set; }

        public decimal Discount_price { get; set; }

        public string Description { get; set; }

        public DateTime? Warranty_period { get; set; }

        public string Photo { get; set; }

        [StringLength(5)]
        public string Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_details> Order_details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protfolio> Protfolio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Designer_service> Designer_service { get; set; }

        public virtual Service_types Service_types { get; set; }
    }
}
