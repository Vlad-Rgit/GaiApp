namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using GaiApp.Attributes;

    [Table("Model")]
    public partial class Model : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            AutoTypes = new HashSet<AutoType>();
        }

        public int ModelId { get; set; }

        [Required]
        [StringLength(255)]
        [SearchProperty]
        public string ModelName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutoType> AutoTypes { get; set; }
    }
}
