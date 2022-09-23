using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Price")]
    public partial class Price
    {
        [Key]
        [Column("PriceCD")]
        public int PriceCd { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal PriceValue { get; set; }
        [Column("ModeCD")]
        public int ModeCd { get; set; }

        [ForeignKey(nameof(ModeCd))]
        [InverseProperty(nameof(Mode.Prices))]
        public virtual Mode ModeCdNavigation { get; set; }
    }
}
