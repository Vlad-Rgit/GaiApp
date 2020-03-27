namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News : Entity
    {
        public int NewsId { get; set; }

        [Required]
        [StringLength(200)]
        public string Header { get; set; }

        [StringLength(500)]
        public string ImageLink { get; set; }

        public string Description { get; set; }

        [StringLength(500)]
        public string BrowserLink { get; set; }
    }
}
