namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using GaiApp.Attributes;

    [Table("Policeman")]
    public partial class Policeman : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Policeman()
        {
            Desicions = new HashSet<Desicion>();
            PolicemenInPosts = new HashSet<PolicemenInPost>();
            Punishments = new HashSet<Punishment>();
        }

        [Key]
        [StringLength(50)]
        [SearchProperty]
        public string PolicemanNumber { get; set; }

        [Required]
        [StringLength(255)]
        [SearchProperty]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [SearchProperty]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        [SearchProperty]
        public string Patronymic { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Desicion> Desicions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PolicemenInPost> PolicemenInPosts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Punishment> Punishments { get; set; }
    }
}
