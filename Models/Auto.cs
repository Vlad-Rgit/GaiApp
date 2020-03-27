namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using GaiApp.Attributes;

    [Table("Auto")]
    public partial class Auto : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auto()
        {
            Desicions = new HashSet<Desicion>();
        }

        public int AutoId { get; set; }

        [SearchProperty(nameof(DriverLicense))]
        [Required]
        [StringLength(50)]
        public string DriverLicense { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public int ColorId { get; set; }

        [SearchProperty(nameof(RegistrationDate))]
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [SearchProperty(nameof(MadeDate))]
        [Column(TypeName = "date")]
        public DateTime MadeDate { get; set; }

        public virtual AutoType AutoType { get; set; }

        public virtual Color Color { get; set; }

        public virtual Driver Driver { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Desicion> Desicions { get; set; }
    }
}
