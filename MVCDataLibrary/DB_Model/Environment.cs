namespace MVCDataLibrary.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Environment")]
    public partial class Environment
    {
        public int id { get; set; }

        public string Environment_photo { get; set; }

        public string Environment_description { get; set; }
    }
}
