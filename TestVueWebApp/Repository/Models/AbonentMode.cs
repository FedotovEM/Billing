using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("AbonentMode")]
    public partial class AbonentMode
    {
        public AbonentMode()
        {
            NachislSummas = new HashSet<NachislSumma>();
            PaySummas = new HashSet<PaySumma>();
        }

        [Key]
        [Column("AbonentModeСD")]
        public int AbonentModeСd { get; set; }
        [Required]
        [Column("AccountCD")]
        [StringLength(6)]
        public string AccountCd { get; set; }
        [Column("ModeCD")]
        public int ModeCd { get; set; }
        public bool Counterr { get; set; }

        [ForeignKey(nameof(AccountCd))]
        [InverseProperty(nameof(Abonent.AbonentModes))]
        public virtual Abonent AccountCdNavigation { get; set; }
        [ForeignKey(nameof(ModeCd))]
        [InverseProperty(nameof(Mode.AbonentModes))]
        public virtual Mode ModeCdNavigation { get; set; }
        [InverseProperty(nameof(NachislSumma.AbonentModeСdNavigation))]
        public virtual ICollection<NachislSumma> NachislSummas { get; set; }
        [InverseProperty(nameof(PaySumma.AbonentModeСdNavigation))]
        public virtual ICollection<PaySumma> PaySummas { get; set; }
    }
}
