namespace Code48Software.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Postal { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
