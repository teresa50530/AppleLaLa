using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_AppleLaLa.Models
{
    public class CustomerModel
    {
        [StringLength(10)]
        public string Cust_id { get; set; }

        [Required]
        [StringLength(256)]
        public string Account { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}