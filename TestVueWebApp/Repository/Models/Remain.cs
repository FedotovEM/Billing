using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    public partial class Remain
    {
        [Key]
        [Column("RemainCD")]
        public int RemainCd { get; set; }
        [Required]
        [Column("AccountCD")]
        [StringLength(6)]
        public string AccountCd { get; set; }
        [Column("ServiceCD")]
        public int ServiceCd { get; set; }
        public short Remmonth { get; set; }
        public short Remyear { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? Remainsum { get; set; }

        [ForeignKey(nameof(AccountCd))]
        [InverseProperty(nameof(Abonent.Remains))]
        public virtual Abonent AccountCdNavigation { get; set; }
        [ForeignKey(nameof(ServiceCd))]
        [InverseProperty(nameof(Service.Remains))]
        public virtual Service ServiceCdNavigation { get; set; }
    }
}
