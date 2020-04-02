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

        [Key]
        [StringLength(17)]
        public string VIN { get; set; }

      
        [Required]
        [StringLength(50)]
        [SearchProperty]
        public string DriverLicense { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public int ColorId { get; set; }


        [RangeProperty(nameof(RegistrationDate))]
        [SearchProperty]
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [RangeProperty(nameof(MadeDate))]
        [SearchProperty]
        [Column(TypeName = "date")]
        public DateTime MadeDate { get; set; } = DateTime.Now;

        [SearchObject]
        public virtual AutoType AutoType { get; set; } 

        [SearchObject]
        public virtual Color Color { get; set; } 

        public virtual Driver Driver { get; set; } 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Desicion> Desicions { get; set; }
    }
}
