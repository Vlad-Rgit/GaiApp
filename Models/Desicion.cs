namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using GaiApp.Attributes;

    [Table("Desicion")]
    public partial class Desicion : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Desicion()
        {
            InfrigmentInDecisions = new HashSet<InfrigmentInDecision>();
        }

        public int DesicionId { get; set; }

        [Required]
        [ForeignKey("Auto")]
        [StringLength(17)]
        [SearchProperty]
        public string VIN { get; set; }

        [Required]
        [StringLength(50)]
        [SearchProperty]
        public string DriverLicense { get; set; }

        [Required]
        [StringLength(10)]
        [SearchProperty]
        public string ArticleCode { get; set; }

        [Required]
        [StringLength(50)]
        [SearchProperty]
        public string PolicemanNumber { get; set; }

        [SearchProperty]
        [RangeProperty]
        public DateTime PunishmentDateTime { get; set; }

        public int AddressId { get; set; }

        public virtual Article Article { get; set; }

        public virtual Auto Auto { get; set; }

        public virtual Address InfrigmentAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfrigmentInDecision> InfrigmentInDecisions { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Policeman Policeman { get; set; }
    }
}
