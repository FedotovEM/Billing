using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("PaySumma")]
    public partial class PaySumma
    {
        [Key]
        [Column("PayFactCD")]
        public int PayFactCd { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal PaySum { get; set; }
        [Column(TypeName = "date")]
        public DateTime PayDate { get; set; }
        public short PayMonth { get; set; }
        public short PayYear { get; set; }
        [Column("AbonentModeСD")]
        public int AbonentModeСd { get; set; }
        [Required]
        [StringLength(30)]
        public string PayType { get; set; }
        [Column("ReceptionPointCD")]
        public int ReceptionPointCd { get; set; }

        [ForeignKey(nameof(AbonentModeСd))]
        [InverseProperty(nameof(AbonentMode.PaySummas))]
        public virtual AbonentMode AbonentModeСdNavigation { get; set; }
        [ForeignKey(nameof(ReceptionPointCd))]
        [InverseProperty(nameof(ReceptionPoint.PaySummas))]
        public virtual ReceptionPoint ReceptionPointCdNavigation { get; set; }
    }
}
