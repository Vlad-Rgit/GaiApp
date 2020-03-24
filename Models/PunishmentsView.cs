namespace GaiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PunishmentsView")]
    public partial class PunishmentsView
    {
        [Key]
        [Column("Номер протокола", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_протокола { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Удостоверение { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Имя { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Фамилия { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string Отчество { get; set; }

        [Key]
        [Column("Место нарушения", Order = 5)]
        [StringLength(522)]
        public string Место_нарушения { get; set; }

        [Key]
        [Column("Номер статьи", Order = 6)]
        [StringLength(10)]
        public string Номер_статьи { get; set; }

        [Key]
        [Column("Описание статьи", Order = 7)]
        [StringLength(500)]
        public string Описание_статьи { get; set; }

        [Key]
        [Column("Вид наказания", Order = 8)]
        [StringLength(100)]
        public string Вид_наказания { get; set; }

        [Column("Размер штрафа")]
        public decimal? Размер_штрафа { get; set; }

        [Key]
        [Column("Дата вынесения штрафа", Order = 9)]
        public DateTime Дата_вынесения_штрафа { get; set; }

        [Key]
        [Column("Конец срока выплаты", Order = 10, TypeName = "date")]
        public DateTime Конец_срока_выплаты { get; set; }

        [Key]
        [Column(Order = 11)]
        public bool Выполнено { get; set; }
    }
}
