namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PolicemenInPost")]
    public partial class PolicemenInPost : Entity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string PolicemanNumber { get; set; }

        public TimeSpan? ShiftStart { get; set; }

        public TimeSpan? ShiftEnd { get; set; }

        public virtual Policeman Policeman { get; set; }

        public virtual Post Post { get; set; }
    }
}
