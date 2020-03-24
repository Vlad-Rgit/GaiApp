namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InfrigmentInDecision")]
    public partial class InfrigmentInDecision
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InfrigmentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DecisionId { get; set; }

        public decimal? Penalty { get; set; }

        public virtual Desicion Desicion { get; set; }

        public virtual Infrigment Infrigment { get; set; }

        public virtual Punishment Punishment { get; set; }
    }
}
