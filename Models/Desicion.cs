namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Desicion")]
    public partial class Desicion : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Desicion()
        {
            InfrigmentInDecisions = new HashSet<InfrigmentInDecision>();
            Punishments = new HashSet<Punishment>();
        }

        public int DesicionId { get; set; }

        [Required]
        [ForeignKey("Auto")]
        [StringLength(17)]
        public string VIN { get; set; }

        [Required]
        [StringLength(50)]
        public string DriverLicense { get; set; }

        [Required]
        [StringLength(10)]
        public string ArticleCode { get; set; }

        [Required]
        [StringLength(50)]
        public string PolicemanNumber { get; set; }

        public DateTime PunishmentDateTime { get; set; }

        public virtual Article Article { get; set; }

        public virtual Auto Auto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfrigmentInDecision> InfrigmentInDecisions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Punishment> Punishments { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Policeman Policeman { get; set; }
    }
}
