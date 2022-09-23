using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestVueWebApp.Repository.Models
{
    public partial class Service
    {
        public Service()
        {
            Modes = new HashSet<Mode>();
            Remains = new HashSet<Remain>();
        }

        [Key]
        [Column("ServiceCD")]
        public int ServiceCd { get; set; }
        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }
        [Column("UnitsCD")]
        public int UnitsCd { get; set; }

        [ForeignKey(nameof(UnitsCd))]
        [InverseProperty(nameof(Unit.Services))]
        public virtual Unit UnitsCdNavigation { get; set; }
        [InverseProperty(nameof(Mode.ServiceCdNavigation))]
        public virtual ICollection<Mode> Modes { get; set; }
        [InverseProperty(nameof(Remain.ServiceCdNavigation))]
        public virtual ICollection<Remain> Remains { get; set; }
    }
}
