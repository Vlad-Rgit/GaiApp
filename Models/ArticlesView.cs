namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticlesView")]
    public partial class ArticlesView : Entity
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Статья { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string Описание { get; set; }

        [Key]
        [Column("Вид наказания", Order = 2)]
        [StringLength(100)]
        public string Вид_наказания { get; set; }

        public decimal? Минимум { get; set; }

        public decimal? Максимум { get; set; }
    }
}
