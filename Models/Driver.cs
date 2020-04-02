namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using GaiApp.Attributes;

    [Table("Driver")]
    public partial class Driver : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            Autoes = new HashSet<Auto>();
            Desicions = new HashSet<Desicion>();
        }

        [Key]
        [StringLength(50)]
        [SearchProperty]
        public string LicenseNumber { get; set; }

        [Required]
        [StringLength(255)]
        [SearchProperty]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [SearchProperty]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        [SearchProperty]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(20)]
        [SearchProperty]
        public string PhoneNumber { get; set; }

        [NotMapped]
        public string FIO
        {
            get => $"{LastName} {Name} {Patronymic}";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auto> Autoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Desicion> Desicions { get; set; }


        public override string ToString()
        {
            return LicenseNumber;
        }
    }
}
