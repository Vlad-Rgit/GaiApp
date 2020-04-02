namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using GaiApp.Attributes;

    [Table("PunishmentExecution")]
    public partial class PunishmentExecution : Entity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InfrigmentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DesicionId { get; set; }

        public bool IsComplete { get; set; }

        [SearchProperty]
        [RangeProperty]
        public DateTime? CompleteDateTime { get; set; }

   


        [Column(TypeName = "date")]
        [SearchProperty]
        [RangeProperty]
        public DateTime EndDate { get; set; }

        public virtual Punishment Punishment { get; set; }
    }
}
