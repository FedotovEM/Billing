using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    [Table("Mode")]
    public partial class Mode
    {
        public Mode()
        {
            AbonentModes = new HashSet<AbonentMode>();
            Prices = new HashSet<Price>();
        }

        [Key]
        [Column("ModeCD")]
        public int ModeCd { get; set; }
        [Required]
        [StringLength(230)]
        public string ModeName { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal Norma { get; set; }
        [Column("ServiceCD")]
        public int ServiceCd { get; set; }

        [ForeignKey(nameof(ServiceCd))]
        [InverseProperty(nameof(Service.Modes))]
        public virtual Service ServiceCdNavigation { get; set; }
        [InverseProperty(nameof(AbonentMode.ModeCdNavigation))]
        public virtual ICollection<AbonentMode> AbonentModes { get; set; }
        [InverseProperty(nameof(Price.ModeCdNavigation))]
        public virtual ICollection<Price> Prices { get; set; }
    }
}
