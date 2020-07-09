namespace Code48Software.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package
    {
        public int Id { get; set; }

        [Required]
        public string PackageCost { get; set; }

        public string Name { get; set; }

        public DateTime ContractStart { get; set; }

        public DateTime ContractEnd { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
