namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Punishment")]
    public partial class Punishment : Entity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DecisionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InfrigmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string PolicemanNumber { get; set; }

        public DateTime PunishmentDateTime { get; set; }

        public virtual InfrigmentInDecision InfrigmentInDecision { get; set; }

        public virtual Policeman Policeman { get; set; }

        public virtual PunishmentExecution PunishmentExecution { get; set; }
    }
}
