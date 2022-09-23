using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("NachislSumma")]
    public partial class NachislSumma
    {
        [Key]
        [Column("NachislFactCD")]
        public int NachislFactCd { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal NachislSum { get; set; }
        public short NachislYear { get; set; }
        public short NachislMonth { get; set; }
        [Required]
        [StringLength(20)]
        public string NachType { get; set; }
        [Column("AbonentModeСD")]
        public int AbonentModeСd { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal CountResources { get; set; }

        [ForeignKey(nameof(AbonentModeСd))]
        [InverseProperty(nameof(AbonentMode.NachislSummas))]
        public virtual AbonentMode AbonentModeСdNavigation { get; set; }
    }
}
