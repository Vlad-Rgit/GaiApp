namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Infrigment")]
    public partial class Infrigment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Infrigment()
        {
            InfrigmentInDecisions = new HashSet<InfrigmentInDecision>();
            Articles = new HashSet<Article>();
        }

        public int InfrigmentId { get; set; }

        public int? InfrigmentKindId { get; set; }

        public decimal? From { get; set; }

        public decimal? To { get; set; }

        public virtual InfrigmentKind InfrigmentKind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfrigmentInDecision> InfrigmentInDecisions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
