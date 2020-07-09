namespace Code48Software.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int Id { get; set; }

        [Required]
        public string Phone { get; set; } // Remove Phone number

        [Required]
        public string TimeStamp { get; set; }

        [Required]
        public string Date { get; set; }

        public int EventTypeId { get; set; }

        public int VendorId { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
