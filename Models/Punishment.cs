namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using GaiApp.Attributes;

    [Table("Punishment")]
    public partial class Punishment : Entity
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InfrigmentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DecisionId { get; set; }

        [Required]
        [StringLength(50)]
        [SearchProperty]
        public string PolicemanNumber { get; set; }

        [SearchProperty]
        [RangeProperty]
        public DateTime PunishmentDateTime { get; set; }


        [SearchObject]
        [ForeignKey("InfrigmentId, DecisionId")]
        public virtual InfrigmentInDecision InfrigmentInDecision { get; set; }

        public virtual Policeman Policeman { get; set; }

        [SearchObject]
        public virtual PunishmentExecution PunishmentExecution { get; set; }
    }
}
